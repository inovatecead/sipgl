using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;
using ufmt.utils.mail;

namespace ufmt.sig.business.implementation;

[Serializable]
public class AutenticacaoBO : IAutenticacaoBO, IDisposable
{
	private ISession session;

	internal AutenticacaoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public Usuario GetUsuario(string nomeAcesso, string senhaAcesso)
	{
		Usuario usuario = null;
		usuario = GetUsuario(nomeAcesso);
		if (usuario == null)
		{
			throw new Exception("Nome de acesso de usuário inexistente.");
		}
		if (!usuario.CompareSenha(senhaAcesso))
		{
			throw new Exception("Senha de acesso do usuário inválida.");
		}
		usuario.DataUltimoAcesso = DateTime.Now;
		SalveUsuario(usuario);
		return usuario;
	}

	public void AtualizaUsuario(Usuario novousuario)
	{
		Usuario usuario = GetUsuario(novousuario.UsuarioUID);
		if (usuario == null)
		{
			throw new Exception("Nome de acesso de usuário inexistente.");
		}
		if (!string.IsNullOrEmpty(novousuario.SenhaAcesso))
		{
			usuario.SetSenhaAcesso(novousuario.SenhaAcesso);
		}
		if (!novousuario.NomeAcesso.Equals(usuario.NomeAcesso))
		{
			if (GetUsuario(usuario.NomeAcesso) != null)
			{
				throw new Exception("Nome de acesso de usuário em uso.");
			}
			usuario.NomeAcesso = novousuario.NomeAcesso;
		}
		SalveUsuario(usuario);
	}

	public void CrieUsuario(Pessoa pessoa, string nomeAcesso, IList<Perfil> perfis)
	{
		string mensagem = "\nPor favor, acesse novamente o sistema informando seu CPF como nome de login e a senha abaixo.\nNa primeira vez, o sistema lhe pedirá para trocar a senha, assim você poderá colocar a senha que achar melhor.\n\nAtenciosamente,\nSecretaria de Tecnologia da Informação\nUniversidade Federal de Mato Grosso";
		CrieUsuario(null, perfis, pessoa, nomeAcesso, mensagem);
	}

	public void CrieUsuario(IList<Permissao> permissoes, Pessoa pessoa, string nomeAcesso)
	{
		string mensagem = "\nPor favor, acesse novamente o sistema informando seu CPF como nome de login e a senha abaixo.\nNa primeira vez, o sistema lhe pedirá para trocar a senha, assim você poderá colocar a senha que achar melhor.\n\nAtenciosamente,\nSecretaria de Tecnologia da Informação\nUniversidade Federal de Mato Grosso";
		CrieUsuario(permissoes, null, pessoa, nomeAcesso, mensagem);
	}

	public void enviarEmail(string emailDestinatario, string tituloDestinatario, string assunto, string conteudo)
	{
		try
		{
			// Credenciais SMTP reais removidas do código-fonte antes da publicação deste
			// repositório (estavam hardcoded: host, remetente e senha em texto plano).
			// Agora lidas de configuração, no mesmo padrão já usado por
			// ufmt.sipgl.View.componentes.Email. Preencha via appSettings/variável de
			// ambiente do ambiente de deploy — nunca com valor real neste arquivo.
			var smtpHost = ConfigurationManager.AppSettings["smtpHost"];
			var smtpPort = int.TryParse(ConfigurationManager.AppSettings["smtpPort"], out var porta) ? porta : (int?)null;
			var remetente = ConfigurationManager.AppSettings["smtpUserAddress"];
			var nomeExibicaoRemetente = ConfigurationManager.AppSettings["smtpUserDisplayName"];
			var senha = ConfigurationManager.AppSettings["smtpUserPassword"];

			Mail.SendMail(smtpHost, smtpPort, remetente, nomeExibicaoRemetente, senha, emailDestinatario, tituloDestinatario, assunto, conteudo, false);
		}
		catch (Exception innerException)
		{
			throw new Exception("Erro ao enviar o e-mail.", innerException);
		}
	}

	public void CrieUsuario(IList<Permissao> permissoes, IList<Perfil> perfis, Pessoa pessoa, string nomeAcesso, string mensagem)
	{
		if (string.IsNullOrEmpty(nomeAcesso))
		{
			throw new ArgumentNullException("Nome de acesso não informado.");
		}
		if (pessoa == null)
		{
			throw new ArgumentNullException("Pessoa não informada.");
		}
		if (string.IsNullOrEmpty(pessoa.Mail))
		{
			throw new ArgumentException("Para criação de usuário é necessário que a pessoa possua e-mail.");
		}
		Usuario usuario = null;
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			usuario = GetUsuarioPorPessoa(pessoa.PessoaUID);
			if (usuario != null)
			{
				throw new Exception("Já existe usuário para a pessoa informada.");
			}
			usuario = new Usuario();
			usuario.DataProximaTrocaSenha = DateTime.Now;
			usuario.Pessoa = pessoa;
			usuario.NomeAcesso = nomeAcesso;
			string text = GerarSenha(4, 2, 0);
			usuario.SetSenhaAcesso(text);
			try
			{
				using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
				{
					pessoaBO.SalvePessoa(pessoa);
				}
				SalveUsuario(usuario);
				if (permissoes != null)
				{
					foreach (Permissao permisso in permissoes)
					{
						SalvePermissaoUsuario(permisso, usuario, null);
					}
				}
				if (perfis != null)
				{
					foreach (Perfil perfi in perfis)
					{
						SalvePerfilUsuario(perfi, usuario, adicionarPermissoesUsuario: true);
					}
				}
				enviarEmail(pessoa.Mail, pessoa.Nome, "UFMT - Sistema Integrado de Gestão", string.Format(mensagem + "\n\nSua senha no sistema é: -> {0} <- (caracteres compreendidos entre as setas)", text));
				if (!isActive)
				{
					transaction.Commit();
				}
			}
			catch (Exception innerException)
			{
				throw new Exception("Não foi possível criar usuário.", innerException);
			}
		}
		catch (Exception ex)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw ex;
		}
	}

	public void CrieUsuario(IList<Permissao> permissoes, IList<Perfil> perfis, Pessoa pessoa, string nomeAcesso, string senhaAcesso, string mensagem)
	{
		if (string.IsNullOrEmpty(nomeAcesso))
		{
			throw new ArgumentNullException("Nome de acesso não informado.");
		}
		if (pessoa == null)
		{
			throw new ArgumentNullException("Pessoa não informada.");
		}
		if (string.IsNullOrEmpty(pessoa.Mail))
		{
			throw new ArgumentException("Para criação de usuário é necessário que a pessoa possua e-mail.");
		}
		Usuario usuario = null;
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			usuario = GetUsuarioPorPessoa(pessoa.PessoaUID);
			if (usuario != null)
			{
				throw new Exception("Já existe usuário para a pessoa informada.");
			}
			usuario = new Usuario();
			usuario.DataProximaTrocaSenha = null;
			usuario.Pessoa = pessoa;
			usuario.NomeAcesso = nomeAcesso;
			usuario.SetSenhaAcesso(senhaAcesso);
			try
			{
				using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
				{
					pessoaBO.SalvePessoa(pessoa);
				}
				SalveUsuario(usuario);
				if (permissoes != null)
				{
					foreach (Permissao permisso in permissoes)
					{
						SalvePermissaoUsuario(permisso, usuario, null);
					}
				}
				if (perfis != null)
				{
					foreach (Perfil perfi in perfis)
					{
						SalvePerfilUsuario(perfi, usuario, adicionarPermissoesUsuario: true);
					}
				}
				enviarEmail(pessoa.Mail, pessoa.Nome, "UFMT - Sistema Integrado de Gestão", string.Format(mensagem + "\n\nSua senha no sistema é: -> {0} <- (caracteres compreendidos entre as setas)", senhaAcesso));
				if (!isActive)
				{
					transaction.Commit();
				}
			}
			catch (Exception innerException)
			{
				throw new Exception("Não foi possível criar usuário.", innerException);
			}
		}
		catch (Exception ex)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw ex;
		}
	}

	public string GerarSenha(short? digitos, short? letras, short? caracteresEspeciais)
	{
		Random random = new Random(DateTime.Now.Millisecond);
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		string text = "23456789";
		string text2 = "abcdefghijkmnpqrstuwxyz";
		string text3 = "@$&,.;:/?";
		if (!digitos.HasValue && !letras.HasValue && !caracteresEspeciais.HasValue)
		{
			string text4 = text + text2 + text3;
			for (int i = 0; i < 5; i++)
			{
				stringBuilder.Append(text4[random.Next(text4.Length - 1)]);
			}
			return stringBuilder.ToString();
		}
		if (digitos.HasValue)
		{
			for (int j = 0; j < digitos.Value; j++)
			{
				stringBuilder.Append(text[random.Next(text.Length - 1)]);
			}
		}
		if (letras.HasValue)
		{
			for (int k = 0; k < letras.Value; k++)
			{
				stringBuilder.Append(text2[random.Next(text2.Length - 1)]);
			}
		}
		if (caracteresEspeciais.HasValue)
		{
			for (int l = 0; l < caracteresEspeciais.Value; l++)
			{
				stringBuilder.Append(text3[random.Next(text3.Length - 1)]);
			}
		}
		while (stringBuilder.Length > 0)
		{
			int num = random.Next(stringBuilder.Length - 1);
			stringBuilder2.Append(stringBuilder[num]);
			stringBuilder.Remove(num, 1);
		}
		return stringBuilder2.ToString();
	}

	public void TroqueSenha(Usuario usuario, string senhaAtual, string novaSenha)
	{
		if (!usuario.CompareSenha(senhaAtual))
		{
			throw new Exception("Senha atual do usuário inválida.");
		}
		usuario.SetSenhaAcesso(novaSenha);
		usuario.DataProximaTrocaSenha = null;
		ITransaction transaction = session.BeginTransaction();
		try
		{
			SalveUsuario(usuario);
			transaction.Commit();
		}
		catch (Exception innerException)
		{
			transaction.Rollback();
			throw new Exception("Não foi possível alterar a senha do usuário.", innerException);
		}
	}

	public void ReiniciarSenha(Usuario usuario)
	{
		if (usuario == null)
		{
			throw new ArgumentNullException("Usuário não informado.");
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		if (!isActive)
		{
			transaction = session.BeginTransaction();
		}
		string text = GerarSenha(4, 2, 0);
		try
		{
			usuario.SetSenhaAcesso(text);
			usuario.DataProximaTrocaSenha = DateTime.Now;
			SalveUsuario(usuario);
			enviarEmail(usuario.Pessoa.Mail, usuario.Pessoa.Nome, "Sistema Integrado de Gestão", $"Foi requisitada uma reinicialização da senha de sua conta.\n\nSua senha no sistema agora é: -> {text} <- (caracteres compreendidos entre as setas)\n\nEntre em qualquer Sistema Integrado de Gestão (SGE, SisReq, SisCofre), informe a senha acima e atualize-a para uma de sua escolha.");
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível reiniciar a senha do usuário", innerException);
		}
	}

	protected void SalvePerfilUsuario(Perfil perfil, Usuario usuario, bool adicionarPermissoesUsuario)
	{
		PerfilUsuario perfilUsuario = null;
		try
		{
			perfilUsuario = new PerfilUsuario();
			perfilUsuario.Perfil = perfil;
			perfilUsuario.Usuario = usuario;
			session.SaveOrUpdate(perfilUsuario);
			if (!adicionarPermissoesUsuario)
			{
				return;
			}
			foreach (Permissao item in GetPermissoesPorPerfil(perfil.PerfilUID))
			{
				SalvePermissaoUsuario(item, usuario, null);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível salvar perfil para o usuário.", innerException);
		}
	}

	public void SalvePermissaoUsuario(Permissao permissao, Usuario usuario, DateTime? dataLimite)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		PermissaoUsuario permissaoUsuario = null;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			PermissaoUsuario permissaoUsuario2 = GetPermissaoUsuario(permissao.Aplicacao.AplicacaoUID, permissao.PermissaoUID, usuario.UsuarioUID);
			if (permissaoUsuario2 != null)
			{
				permissaoUsuario = permissaoUsuario2;
			}
			else
			{
				permissaoUsuario = new PermissaoUsuario();
				permissaoUsuario.Permissao = permissao;
				permissaoUsuario.Usuario = usuario;
			}
			permissaoUsuario.DataLimite = dataLimite;
			session.SaveOrUpdate(permissaoUsuario);
			session.Flush();
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar a permissão para o usuário.", innerException);
		}
	}

	protected void SalveUsuario(Usuario usuario)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(usuario);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar o usuário.", innerException);
		}
	}

	public Usuario GetUsuario(long usuarioUID)
	{
		Usuario usuario = null;
		try
		{
			IQuery query = session.CreateQuery("select u from Usuario u where u.UsuarioUID = :usuarioUID").SetParameter("usuarioUID", usuarioUID);
			return query.UniqueResult<Usuario>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar usuário através de seu identificador único.", innerException);
		}
	}

	protected Usuario GetUsuario(string nomeAcesso)
	{
		Usuario usuario = null;
		try
		{
			IQuery query = session.CreateQuery("select u from Usuario u where u.NomeAcesso like :nomeAcesso").SetParameter("nomeAcesso", nomeAcesso);
			return query.UniqueResult<Usuario>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar usuário através de seu nome de acesso.", innerException);
		}
	}

	public bool VerificaNomeAcesso(string nomeAcesso)
	{
		if (GetUsuario(nomeAcesso) != null)
		{
			return false;
		}
		return true;
	}

	public Usuario GetUsuarioPorPessoa(long pessoaUID)
	{
		Usuario usuario = null;
		try
		{
			IQuery query = session.CreateQuery("select u from Usuario u where u.Pessoa.PessoaUID = :pessoaUID").SetParameter("pessoaUID", pessoaUID);
			return query.UniqueResult<Usuario>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar usuário através da pessoa informada.", innerException);
		}
	}

	protected IEnumerable<Permissao> GetPermissoesPorPerfil(long perfilUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct pp.Permissao from PermissaoPerfil pp where pp.Perfil.PerfilUID = :perfilUID").SetParameter("perfilUID", perfilUID);
			return query.Enumerable<Permissao>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar permissões por perfil.", innerException);
		}
	}

	public Permissao GetPermissao(long permissaoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select p from Permissao p where p.PermissaoUID = :permissaoUID").SetParameter("permissaoUID", permissaoUID);
			return query.UniqueResult<Permissao>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a permissão indicada.", innerException);
		}
	}

	public IList<Permissao> GetPermissaoPorAplicacao(long aplicacaoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select p from Permissao p where p.Aplicacao = :aplicacaoUID").SetParameter("aplicacaoUID", aplicacaoUID);
			return query.List<Permissao>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as permissões desta aplicação.", innerException);
		}
	}

	public Perfil GetPerfil(string nome)
	{
		try
		{
			IQuery query = session.CreateQuery("select p from Perfil p where p.Nome like :nome").SetParameter("nome", nome);
			return query.UniqueResult<Perfil>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar perfil através de seu nome.", innerException);
		}
	}

	public bool VerifiquePermissao(long aplicacaoUID, long permissaoUID, long usuarioUID)
	{
		try
		{
			return GetPermissaoUsuario(aplicacaoUID, permissaoUID, usuarioUID) != null;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível verificar a permissão do usuário.", innerException);
		}
	}

	public IEnumerable<PermissaoUsuario> GetPermissoesUsuario(long aplicacaoUID, long usuarioUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select pu from PermissaoUsuario pu where pu.Usuario.UsuarioUID = :usuarioUID   and pu.Permissao.Aplicacao.AplicacaoUID = :aplicacaoUID  and (pu.DataLimite is null or :now < pu.DataLimite )").SetParameter("usuarioUID", usuarioUID).SetParameter("aplicacaoUID", aplicacaoUID)
				.SetParameter("now", DateTime.Now);
			return query.Enumerable<PermissaoUsuario>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as permissões do usuário.", innerException);
		}
	}

	public PermissaoUsuario GetPermissaoUsuario(long aplicacaoUID, long permissaoUID, long usuarioUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select pu from PermissaoUsuario pu where pu.Usuario.UsuarioUID = :usuarioUID   and (pu.Permissao.PermissaoUID = :permissaoUID or :permissaoUID is null)  and pu.Permissao.Aplicacao.AplicacaoUID = :aplicacaoUID  and (pu.DataLimite is null or :now < pu.DataLimite )").SetParameter("usuarioUID", usuarioUID).SetParameter("permissaoUID", permissaoUID)
				.SetParameter("aplicacaoUID", aplicacaoUID)
				.SetParameter("now", DateTime.Now);
			return query.UniqueResult<PermissaoUsuario>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a permissão do usuário.", innerException);
		}
	}

	public PermissaoUsuario GetPermissaoUsuario(long permissaoUsuarioUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select pu from PermissaoUsuario pu where pu.PermissaoUsuarioUID = :permissaoUsuarioUID ").SetParameter("permissaoUsuarioUID", permissaoUsuarioUID);
			return query.UniqueResult<PermissaoUsuario>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a permissão do usuário.", innerException);
		}
	}

	public void trocarEmail(Pessoa pessoa, string novoEmail)
	{
		if (pessoa == null)
		{
			throw new ArgumentNullException("Pessoa não informada.");
		}
		string text = GerarSenha(16, 16, 0);
		ConfirmaEmail confirmaEmail = null;
		try
		{
			IQuery query = session.CreateQuery("select c from ConfirmaEmail c where c.Pessoa.PessoaUID = :pessoaUID ").SetParameter("pessoaUID", pessoa.PessoaUID);
			confirmaEmail = query.UniqueResult<ConfirmaEmail>();
		}
		catch (Exception)
		{
		}
		if (confirmaEmail == null)
		{
			confirmaEmail = new ConfirmaEmail();
			confirmaEmail.Pessoa = pessoa;
		}
		confirmaEmail.CodigoConfirmacao = text;
		confirmaEmail.NovoEmail = novoEmail;
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(confirmaEmail);
			enviarEmail(novoEmail, pessoa.Nome, "UFMT - Sistema Integrado de Gestão", $"Foi solicitado uma atualização do e-mail de {pessoa.Nome} no Sistema de Gestão Integrada da UFMT.\n\nCaso você tenha feita essa solicitação, entre no link abaixo para confirmar a alteração.\n\nhttp://sistemas.ufmt.br/ConfirmacaoEmail/Default.aspx?codigo={text}\n\n\n\nEsta é uma mensagem automática. Por favor não responda este e-mail.\n\nQualquer dúvida entre em contato com a STI através do telefone (65) 3615-8246");
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Houve problema na atualização do e-mail do usuário.", innerException);
		}
	}

	public void confirmarEmail(string codigoConfirmacao)
	{
		ConfirmaEmail confirmaEmail = null;
		try
		{
			IQuery query = session.CreateQuery("select c from ConfirmaEmail c where c.CodigoConfirmacao = :codigoConfirmacao ").SetParameter("codigoConfirmacao", codigoConfirmacao);
			confirmaEmail = query.UniqueResult<ConfirmaEmail>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Código de confirmação inválido.", innerException);
		}
		if (confirmaEmail == null)
		{
			throw new Exception("Código de confirmação inválido.");
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Pessoa pessoa = confirmaEmail.Pessoa;
			pessoa.Mail = confirmaEmail.NovoEmail;
			session.SaveOrUpdate(pessoa);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException2)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Houve um problema ao atualizar o e-mail do usuário.", innerException2);
		}
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.Delete(confirmaEmail);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
		}
	}

	public Pessoa GetPessoa(long usuarioUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select u.Pessoa from Usuario u where u.UsuarioUID = :usuarioUID ").SetParameter("usuarioUID", usuarioUID);
			return query.UniqueResult<Pessoa>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a pessoa.", innerException);
		}
	}
}

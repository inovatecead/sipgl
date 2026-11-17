using System;
using System.Collections.Generic;
using System.Linq;
using ufmt.sig.business;
using ufmt.sig.entity;

namespace ufmt.sipgl.Business;

public class AutenticacaoBO
{
	public Usuario Login(string cpf, string senha)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		return autenticacaoBO.GetUsuario(cpf, senha);
	}

	public bool VerificaPermissaoEspecifica(long usuarioUID, long permissaoUID, int aplicacaoUID)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		if (autenticacaoBO.GetPermissaoUsuario(aplicacaoUID, permissaoUID, usuarioUID) != null)
		{
			return true;
		}
		return false;
	}

	public byte GetTipoTipoSolicitanteCorrecao(string perfil)
	{
		byte result = 2;
		if (perfil.ToLower() == "administrador")
		{
			result = 1;
		}
		return result;
	}

	public List<PermissaoUsuario> VerificaPermissoes(long usuarioUID, int aplicacaoUID)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		return autenticacaoBO.GetPermissoesUsuario(aplicacaoUID, usuarioUID).ToList();
	}

	public List<Permissao> GetPermissoes(long usuarioUID, int aplicacaoUID)
	{
		List<PermissaoUsuario> list = new AutenticacaoBO().VerificaPermissoes(usuarioUID, aplicacaoUID);
		List<Permissao> list2 = new List<Permissao>();
		foreach (PermissaoUsuario item in list)
		{
			Permissao permissao = new Permissao();
			permissao.PermissaoUID = item.Permissao.PermissaoUID;
			permissao.Nome = item.Permissao.Nome;
			permissao.Descricao = item.Permissao.Descricao;
			permissao.Aplicacao = item.Permissao.Aplicacao;
			list2.Add(permissao);
		}
		return list2;
	}

	public Usuario GetUsuario(long usuarioUID)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		return autenticacaoBO.GetUsuario(usuarioUID);
	}

	public bool criaUsuario(string cpf, DateTime dataNascimento, string email)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		try
		{
			Pessoa pessoa = GetPessoa(cpf, email);
			autenticacaoBO.CrieUsuario(pessoa, cpf, null);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		return true;
	}

	public Pessoa GetPessoa(string cpf, string email)
	{
		using IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>();
		Pessoa pessoa = pessoaBO.GetPessoa(cpf);
		if (pessoa != null)
		{
			if (!string.IsNullOrEmpty(email))
			{
				pessoa.Mail = email;
				pessoaBO.SalvePessoa(pessoa);
				return pessoaBO.GetPessoa(cpf);
			}
			throw new Exception("O e-mail é nulo.");
		}
		throw new Exception("Pessoa não encontrada");
	}

	public Servidor GetServidor(long servidorUID)
	{
		using IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>();
		return pessoaBO.GetServidor(servidorUID) ?? throw new Exception("Pessoa não encontrada");
	}

	public Servidor GetServidor(string registro)
	{
		using IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>();
		return pessoaBO.GetServidor(registro, 'S') ?? throw new Exception("Pessoa não encontrada");
	}

	public Servidor GetServidorAtivo(long pessoaUID)
	{
		using IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>();
		return pessoaBO.GetServidorAtivo(pessoaUID);
	}

	public bool TrocaDeSenha(Usuario usuario, string senhaAtual, string novaSenha)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		try
		{
			autenticacaoBO.TroqueSenha(usuario, senhaAtual, novaSenha);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public bool DefinePermissao(long pessoaUID, int permissaoUID, int aplicacaoUID, DateTime? dataLimite)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		Usuario usuarioPorPessoa = autenticacaoBO.GetUsuarioPorPessoa(pessoaUID);
		if (usuarioPorPessoa == null)
		{
			return false;
		}
		Permissao permissao = new Permissao();
		permissao.PermissaoUID = permissaoUID;
		Aplicacao aplicacao = new Aplicacao();
		aplicacao.AplicacaoUID = aplicacaoUID;
		permissao.Aplicacao = aplicacao;
		autenticacaoBO.SalvePermissaoUsuario(permissao, usuarioPorPessoa, dataLimite);
		return true;
	}

	public Usuario GetUsuarioPorPessoa(int pessoaUID)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		return autenticacaoBO.GetUsuarioPorPessoa(pessoaUID);
	}

	public PermissaoUsuario GetPermissaoUsuario(long permissaoUsuarioUID)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		return autenticacaoBO.GetPermissaoUsuario(permissaoUsuarioUID);
	}

	public Permissao GetPermissao(long permissaoUID)
	{
		using IAutenticacaoBO autenticacaoBO = BusinessFactory.GetInstance<IAutenticacaoBO>();
		return autenticacaoBO.GetPermissao(permissaoUID);
	}
}

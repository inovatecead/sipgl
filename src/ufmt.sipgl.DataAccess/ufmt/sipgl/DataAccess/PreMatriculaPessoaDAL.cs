using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class PreMatriculaPessoaDAL
{
	public PreMatriculaPessoa BuscarPreMatriculaPessoaPorID(long preMatriculaPessoaUID)
	{
		try
		{
			return Contexto.GetContextInstance().PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.preMatriculaPessoaUID == preMatriculaPessoaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public ResultadoOperacao ConfirmacaoEmail(string cpf, string chave)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaPessoa preMatriculaPessoa = contextInstance.PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.cpf == cpf && e.chaveValidacaoCadastro == chave).FirstOrDefault();
			if (preMatriculaPessoa == null)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Nenhum registro contendo os parâmetros informados foi encontrado. Entre em contato com o administrador do sistema.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			preMatriculaPessoa.chaveValidacaoCadastro = "";
			preMatriculaPessoa.emailConfirmado = true;
			contextInstance.Entry(preMatriculaPessoa).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Confirmação de e-mail realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operção. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao SolicitarRecuperacaoSenha(string cpf)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaPessoa preMatriculaPessoa = contextInstance.PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.cpf == cpf).FirstOrDefault();
			if (preMatriculaPessoa == null)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Nenhum registro contendo os parâmetros informados foi encontrado.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			preMatriculaPessoa.dataValidadeChave = DateTime.Now.AddDays(1.0);
			preMatriculaPessoa.chaveRecuperacaoSenha = GerarChaveUnica();
			contextInstance.Entry(preMatriculaPessoa).State = (EntityState)16;
			contextInstance.SaveChanges();
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operção. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public List<PreMatriculaPessoa> FiltrarPreMatriculaPessoa(string nome, string cpf)
	{
		IQueryable<PreMatriculaPessoa> source = Contexto.GetContextInstance().PreMatriculaPessoa.AsQueryable();
		if (!string.IsNullOrWhiteSpace(nome))
		{
			source = source.Where((PreMatriculaPessoa e) => e.nome.ToUpper().Contains(nome.ToUpper()));
		}
		if (!string.IsNullOrWhiteSpace(cpf))
		{
			cpf = cpf.Replace(".", "");
			cpf = cpf.Replace("-", "");
			source = source.Where((PreMatriculaPessoa e) => e.cpf == cpf);
		}
		return source.OrderBy((PreMatriculaPessoa e) => e.nome).ToList();
	}

	public List<PreMatriculaPessoa> ListarPreMatriculaPessoa(string nome, string cpf)
	{
		try
		{
			IQueryable<PreMatriculaPessoa> source = Contexto.GetContextInstance().PreMatriculaPessoa.AsQueryable();
			if (!string.IsNullOrWhiteSpace(nome))
			{
				source = source.Where((PreMatriculaPessoa e) => e.nome.ToUpper().Contains(nome.ToUpper()));
			}
			if (!string.IsNullOrWhiteSpace(cpf))
			{
				cpf = cpf.Replace(".", "");
				cpf = cpf.Replace("-", "");
				source = source.Where((PreMatriculaPessoa e) => e.cpf.Equals(cpf));
			}
			return source.OrderBy((PreMatriculaPessoa e) => e.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public PreMatriculaPessoa BuscarPreMatriculaPessoaPorCPF(string cpf)
	{
		try
		{
			return Contexto.GetContextInstance().PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.cpf == cpf).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public bool ValidarPreMatriculaPessoaPorCPF(string cpf)
	{
		try
		{
			return Contexto.GetContextInstance().PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.cpf == cpf).Any();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public ResultadoOperacao AlterarSenha(long preMatriculaPessoaUID, string senhaAntiga, string novaSenha, string confirmarSenha)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaPessoa preMatriculaPessoa = contextInstance.PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.preMatriculaPessoaUID == preMatriculaPessoaUID).FirstOrDefault();
			string mD5Hash = GetMD5Hash(senhaAntiga);
			if (!preMatriculaPessoa.senha.Equals(mD5Hash))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Senha Antiga é incompatível.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (novaSenha.Length < 6 || confirmarSenha.Length < 6)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Senha deve contar no mínimo 6 caracteres.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (!novaSenha.Equals(confirmarSenha))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Os campos 'Nova Senha' e 'Confirmar Senha' são incompatíveis.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			preMatriculaPessoa.senha = GetMD5Hash(novaSenha);
			contextInstance.Entry(preMatriculaPessoa).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao RecuperarSenha(string cpf, string senha)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaPessoa preMatriculaPessoa = contextInstance.PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.cpf == cpf).FirstOrDefault();
			preMatriculaPessoa.dataValidadeChave = null;
			preMatriculaPessoa.chaveRecuperacaoSenha = "";
			preMatriculaPessoa.senha = GetMD5Hash(senha);
			contextInstance.Entry(preMatriculaPessoa).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Senha Alterada com sucesso. Faça login para acessar sua conta.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public string GetMD5Hash(string input)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString().ToLower();
	}

	public ViewPreMatriculaPessoa BuscarViewPreMatriculaPessoaPorID(long preMatriculaPessoaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ViewPreMatriculaPessoa.Where((ViewPreMatriculaPessoa e) => e.preMatriculaPessoaUID == preMatriculaPessoaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public int? GetInstituicaoEnsinoSuperiorPorId(long instituicaoEnsinoSuperiorUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.InstituicaoEnsino
				where (long)c.instituicaoEnsinoUID == instituicaoEnsinoSuperiorUID
				select c.instituicaoEnsinoUID).SingleOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public int? GetMunicipioPorId(int municipioUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.Municipio
				where c.MunicipioUID == municipioUID
				select c.MunicipioUID).SingleOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao AlterarPreMatriculaPessoa(PreMatriculaPessoa novaPreMatriculaPessoa, bool isAdmin = false)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaPessoa preMatriculaPessoa = contextInstance.PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.preMatriculaPessoaUID == novaPreMatriculaPessoa.preMatriculaPessoaUID).FirstOrDefault();
			preMatriculaPessoa.nome = novaPreMatriculaPessoa.nome;
			preMatriculaPessoa.sexo = novaPreMatriculaPessoa.sexo;
			preMatriculaPessoa.nascimentoData = novaPreMatriculaPessoa.nascimentoData;
			preMatriculaPessoa.nomeMae = novaPreMatriculaPessoa.nomeMae;
			preMatriculaPessoa.nomePai = novaPreMatriculaPessoa.nomePai;
			if (isAdmin)
			{
				preMatriculaPessoa.cpf = novaPreMatriculaPessoa.cpf;
			}
			preMatriculaPessoa.rgNumero = novaPreMatriculaPessoa.rgNumero;
			preMatriculaPessoa.rgUFUID = novaPreMatriculaPessoa.rgUFUID;
			preMatriculaPessoa.rgOrgaoExpedidor = novaPreMatriculaPessoa.rgOrgaoExpedidor;
			preMatriculaPessoa.rgDataExpedicao = novaPreMatriculaPessoa.rgDataExpedicao;
			preMatriculaPessoa.tipoEstadoCivilUID = novaPreMatriculaPessoa.tipoEstadoCivilUID;
			preMatriculaPessoa.nacionalidade = novaPreMatriculaPessoa.nacionalidade;
			preMatriculaPessoa.nascimentoPaisUID = novaPreMatriculaPessoa.nascimentoPaisUID;
			preMatriculaPessoa.naturalidadeMunicipioUID = novaPreMatriculaPessoa.naturalidadeMunicipioUID;
			preMatriculaPessoa.enderecoLogradouro = novaPreMatriculaPessoa.enderecoLogradouro;
			preMatriculaPessoa.enderecoNumero = novaPreMatriculaPessoa.enderecoNumero;
			preMatriculaPessoa.enderecoComplemento = novaPreMatriculaPessoa.enderecoComplemento;
			preMatriculaPessoa.enderecoBairro = novaPreMatriculaPessoa.enderecoBairro;
			preMatriculaPessoa.enderecoCEP = novaPreMatriculaPessoa.enderecoCEP;
			preMatriculaPessoa.enderecoMunicipioUID = novaPreMatriculaPessoa.enderecoMunicipioUID;
			preMatriculaPessoa.telefoneFixo = novaPreMatriculaPessoa.telefoneFixo;
			preMatriculaPessoa.telefoneMovel = novaPreMatriculaPessoa.telefoneMovel;
			preMatriculaPessoa.diplomaGraduacaoExterior = novaPreMatriculaPessoa.diplomaGraduacaoExterior;
			preMatriculaPessoa.numeroRegistroApostilaRevalidacao = novaPreMatriculaPessoa.numeroRegistroApostilaRevalidacao;
			preMatriculaPessoa.graduacaoInstituicaoEnsinoUID = novaPreMatriculaPessoa.graduacaoInstituicaoEnsinoUID;
			preMatriculaPessoa.graduacaoDataColacaoGrau = novaPreMatriculaPessoa.graduacaoDataColacaoGrau;
			preMatriculaPessoa.rgUFUID = novaPreMatriculaPessoa.rgUFUID;
			preMatriculaPessoa.naturalidadeUFUID = novaPreMatriculaPessoa.naturalidadeUFUID;
			preMatriculaPessoa.enderecoUFUID = novaPreMatriculaPessoa.enderecoUFUID;
			preMatriculaPessoa.graduacaoUFUID = novaPreMatriculaPessoa.graduacaoUFUID;
			preMatriculaPessoa.dataHoraUltimaAtualizacao = DateTime.Now;
			preMatriculaPessoa.projetoTipoGraduacaoUID = novaPreMatriculaPessoa.projetoTipoGraduacaoUID;
			preMatriculaPessoa.cursoGraduacao = novaPreMatriculaPessoa.cursoGraduacao;
			preMatriculaPessoa.numeroRegistroDiploma = novaPreMatriculaPessoa.numeroRegistroDiploma;
			preMatriculaPessoa.tituloEleitoral = novaPreMatriculaPessoa.tituloEleitoral;
			preMatriculaPessoa.zona = novaPreMatriculaPessoa.zona;
			preMatriculaPessoa.tituloEleitoralMunicipioUID = novaPreMatriculaPessoa.tituloEleitoralMunicipioUID;
			preMatriculaPessoa.tituloEleitoralUFUID = novaPreMatriculaPessoa.tituloEleitoralUFUID;
			preMatriculaPessoa.passaporte = novaPreMatriculaPessoa.passaporte;
			preMatriculaPessoa.profissao = novaPreMatriculaPessoa.profissao;
			preMatriculaPessoa.localTrabalho = novaPreMatriculaPessoa.localTrabalho;
			preMatriculaPessoa.telefoneComercial = novaPreMatriculaPessoa.telefoneComercial;
			preMatriculaPessoa.celularComercial = novaPreMatriculaPessoa.celularComercial;
			preMatriculaPessoa.emailComercial = novaPreMatriculaPessoa.emailComercial;
			contextInstance.Entry(preMatriculaPessoa).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao SalvarPreMatriculaPessoa(PreMatriculaPessoa preMatriculaPessoa, string senha)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			preMatriculaPessoa.senha = GetMD5Hash(senha);
			preMatriculaPessoa.chaveValidacaoCadastro = GerarChaveUnica();
			preMatriculaPessoa.emailConfirmado = false;
			preMatriculaPessoa.dataHoraCadastro = DateTime.Now;
			preMatriculaPessoa.dataHoraUltimaAtualizacao = DateTime.Now;
			contextInstance.PreMatriculaPessoa.Add(preMatriculaPessoa);
			contextInstance.SaveChanges();
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public string GerarChaveUnica()
	{
		return Guid.NewGuid().ToString();
	}
}

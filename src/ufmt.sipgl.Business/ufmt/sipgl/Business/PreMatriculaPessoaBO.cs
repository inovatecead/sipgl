using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.DataAccess.Utils;

namespace ufmt.sipgl.Business;

public class PreMatriculaPessoaBO
{
	private PreMatriculaPessoaDAL preMatriculaPessoaDAL;

	private Util util;

	public PreMatriculaPessoaBO()
	{
		preMatriculaPessoaDAL = new PreMatriculaPessoaDAL();
		util = new Util();
	}

	public PreMatriculaPessoa BuscarPreMatriculaPessoaPorID(long preMatriculaPessoaUID)
	{
		return preMatriculaPessoaDAL.BuscarPreMatriculaPessoaPorID(preMatriculaPessoaUID);
	}

	public ViewPreMatriculaPessoa BuscarViewPreMatriculaPessoaPorID(long preMatriculaPessoaUID)
	{
		return preMatriculaPessoaDAL.BuscarViewPreMatriculaPessoaPorID(preMatriculaPessoaUID);
	}

	public bool ValidarCPF(string cpf)
	{
		return util.ValidarCPF(cpf);
	}

	public ResultadoOperacao ValidarDadosRecuperacaoSenha(string cpf, string chaveRecuperacaoSenha)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(chaveRecuperacaoSenha))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Este link expirou.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		PreMatriculaPessoa preMatriculaPessoa = preMatriculaPessoaDAL.BuscarPreMatriculaPessoaPorCPF(cpf);
		if (!preMatriculaPessoa.chaveRecuperacaoSenha.Equals(chaveRecuperacaoSenha))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Este link expirou.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (!preMatriculaPessoa.dataValidadeChave.HasValue)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Operação inválida.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (preMatriculaPessoa.dataValidadeChave.Value.CompareTo(DateTime.Now) == -1)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Esta link expirou. Para recuperar sua senha realize uma nova solicitação.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		return resultadoOperacao;
	}

	public List<PreMatriculaPessoa> FiltrarPreMatriculaPessoa(string nome, string cpf)
	{
		return preMatriculaPessoaDAL.FiltrarPreMatriculaPessoa(nome, cpf);
	}

	public ResultadoOperacao SolicitarRecuperacaoSenha(string cpf)
	{
		return preMatriculaPessoaDAL.SolicitarRecuperacaoSenha(cpf);
	}

	public ResultadoOperacao ConfirmacaoEmail(string cpf, string chave)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(chave))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Os parâmetros informados estão incorretos.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (!util.ValidarCPF(cpf))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Os parâmetros informados estão incorretos.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		return preMatriculaPessoaDAL.ConfirmacaoEmail(cpf, chave);
	}

	public ResultadoOperacao ValidarSenhas(string senha, string confirmarSenha)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmarSenha))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Os campos de 'Senha' e 'Confirmar Senha' são obrigatórios.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (senha.Length < 6 || confirmarSenha.Length < 6)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Os campos de senha devem conter no mínimo 6 caracteres";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (!senha.Equals(confirmarSenha))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Os campos de 'Senha' e 'Confirmar Senha' devem conter a mesma senha.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao RecuperarSenha(string senha, string confirmarSenha, string cpf, string chave)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		resultadoOperacao = ValidarSenhas(senha, confirmarSenha);
		if (resultadoOperacao.Erro)
		{
			return resultadoOperacao;
		}
		if (!util.ValidarCPF(cpf))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "O CPF informado é inválido";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		return preMatriculaPessoaDAL.RecuperarSenha(cpf, senha);
	}

	public List<PreMatriculaPessoa> ListarPreMatriculaPessoa(string nome, string cpf)
	{
		try
		{
			return preMatriculaPessoaDAL.ListarPreMatriculaPessoa(nome, cpf);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao VerificarCPF(string cpf)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (string.IsNullOrWhiteSpace(cpf))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Campo CPF é obrigatório.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (cpf.Length != 11)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "CPF informado deve conter 11 dígitos.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (!util.ValidarCPF(cpf))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O CPF informado é inválido";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public bool PossuiIdadeMinima(DateTime dataNascimento)
	{
		int num = 5840;
		if ((DateTime.Now - dataNascimento).TotalDays < (double)num)
		{
			return false;
		}
		return true;
	}

	public PreMatriculaPessoa BuscarPreMatriculaPessoaPorCPF(string cpf)
	{
		return preMatriculaPessoaDAL.BuscarPreMatriculaPessoaPorCPF(cpf);
	}

	public int? GetInstituicaoEnsinoSuperiorPorId(int instituicaoEnsinoSuperiorUID)
	{
		try
		{
			return preMatriculaPessoaDAL.GetInstituicaoEnsinoSuperiorPorId(instituicaoEnsinoSuperiorUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public int? GetMunicipioPorId(int municipioUID)
	{
		try
		{
			return preMatriculaPessoaDAL.GetMunicipioPorId(municipioUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao AlterarPreMatriculaPessoa(PreMatriculaPessoa preMatriculaPessoa, bool isAdmin = false)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (!PossuiIdadeMinima(preMatriculaPessoa.nascimentoData))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "O discente deve possuir idade superior a 15 anos.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (!util.ValidarRG(preMatriculaPessoa.rgNumero))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "RG deve conter apenas dígitos. Sem traços ou pontos.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (isAdmin && !util.ValidarCPF(preMatriculaPessoa.cpf))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "CPF Inválido";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		return preMatriculaPessoaDAL.AlterarPreMatriculaPessoa(preMatriculaPessoa, isAdmin);
	}

	public ResultadoOperacao SalvarPreMatriculaPessoa(PreMatriculaPessoa preMatriculaPessoa, string senha)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (!util.ValidarCPF(preMatriculaPessoa.cpf))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (preMatriculaPessoaDAL.ValidarPreMatriculaPessoaPorCPF(preMatriculaPessoa.cpf))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Já existe um registro com o mesmo CPF informado.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (!PossuiIdadeMinima(preMatriculaPessoa.nascimentoData))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "O discente deve possuir idade superior a 15 anos.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		if (!util.ValidarRG(preMatriculaPessoa.rgNumero))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "RG Inválido";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			return resultadoOperacao;
		}
		return preMatriculaPessoaDAL.SalvarPreMatriculaPessoa(preMatriculaPessoa, senha);
	}
}

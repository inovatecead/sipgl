using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.Business;

public class DiscenteBO
{
	public List<ViewPreMatriculaInscricao> FindRegistrosInscritos(string criterio, int cursoUID)
	{
		try
		{
			return new DiscenteDAL().FindRegistrosInscritos(criterio, cursoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoDiscente BuscarDiscentePorMatriculaInscricao(long preMatriculaInscricaoUID)
	{
		return new DiscenteDAL().BuscarDiscentePorMatriculaInscricao(preMatriculaInscricaoUID);
	}

	public ViewPreMatriculaPessoa AtenticarPreDiscente(string cpf, string senha)
	{
		try
		{
			return new DiscenteDAL().AtenticarPreDiscente(cpf, senha);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Salvar(PreMatriculaPessoa obj, byte operacao)
	{
		_ = DateTime.Now.Year;
		try
		{
			return new DiscenteDAL().Salvar(obj, operacao);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Salvar os registros.", innerException);
		}
	}

	public ResultadoOperacao InscreverCandidato(PreMatriculaInscricao preMatriculaInscricao, ProjetoDiscente projetoDiscente, string observacao, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			PreMatriculaInscricaoOcorrencia preMatriculaInscricaoOcorrencia = new PreMatriculaInscricaoOcorrencia();
			preMatriculaInscricaoOcorrencia.PreMatriculaInscricao = preMatriculaInscricao;
			preMatriculaInscricaoOcorrencia.tipoSituacaoInscricaoUID = preMatriculaInscricao.tipoSituacaoInscricaoUID;
			preMatriculaInscricaoOcorrencia.dataHoraOcorrencia = DateTime.Now;
			preMatriculaInscricaoOcorrencia.observacao = observacao;
			preMatriculaInscricaoOcorrencia.usuarioUID = usuarioUID;
			preMatriculaInscricaoOcorrencia.tipoFormaIngressoUID = projetoDiscente.tipoFormaIngressoUID;
			preMatriculaInscricaoOcorrencia.dataIngresso = projetoDiscente.dataIngresso;
			preMatriculaInscricaoOcorrencia.tipoPeriodoIngressoUID = projetoDiscente.tipoPeridoIngressoUID;
			preMatriculaInscricaoOcorrencia.tipoReservaVagasUID = projetoDiscente.tipoReservaVagasUID;
			preMatriculaInscricaoOcorrencia.periodo = projetoDiscente.periodo;
			preMatriculaInscricaoOcorrencia.ip = ip;
			projetoDiscente.PreMatriculaInscricao = preMatriculaInscricao;
			resultadoOperacao = new PreMatriculaInscricaoDAL().InscreverCandidato(preMatriculaInscricao, preMatriculaInscricaoOcorrencia, projetoDiscente);
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public Curso ValidarCodigoAcesso(string codigoAcesso)
	{
		try
		{
			return new DiscenteDAL().ValidarCodigoAcesso(codigoAcesso);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Verificar o código de acesso.", innerException);
		}
	}

	public List<ViewPreMatriculaInscricao> GetInscricoesPessoa(long preMatriculaPessoaUID)
	{
		try
		{
			return new DiscenteDAL().GetInscricoesPessoa(preMatriculaPessoaUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewPreMatriculaInscricao> GetInscricoesCurso(int cursoUID)
	{
		try
		{
			return new DiscenteDAL().GetInscricoesCurso(cursoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CorrecaoPreMatriculaInscricao> GetCorrecaoPreMatriculaInscricao(long preMatriculaInscricaoUID)
	{
		try
		{
			return new DiscenteDAL().GetCorrecaoPreMatriculaInscricao(preMatriculaInscricaoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public int? GetInstituicaoEnsinoSuperiorPorId(int instituicaoEnsinoSuperiorUID)
	{
		try
		{
			return new DiscenteDAL().GetInstituicaoEnsinoSuperiorPorId(instituicaoEnsinoSuperiorUID);
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
			return new DiscenteDAL().GetMunicipioPorId(municipioUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

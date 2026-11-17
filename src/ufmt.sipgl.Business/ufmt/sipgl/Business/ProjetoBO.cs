using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.Business;

public class ProjetoBO
{
	public List<ProjetoCurso> GetRegistros()
	{
		try
		{
			return new ProjetoDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoCurso> FiltrarProjetoCurso(string nome, bool isTurmaAtiva)
	{
		try
		{
			return new ProjetoDAL().FiltrarProjetoCurso(nome, isTurmaAtiva);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao SalvarProjetoCurso(ProjetoCurso projetoCurso)
	{
		try
		{
			ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
			if (projetoCurso.tipoModalidadeUID == 1)
			{
				projetoCurso.notaMinimaAprovacao = 7;
				projetoCurso.frequenciaMinimaAprovacao = 75;
				projetoCurso.descricaoAva = string.Empty;
			}
			if (projetoCurso.tipoModalidadeUID == 2)
			{
				projetoCurso.notaMinimaAprovacao = 7;
				projetoCurso.frequenciaMinimaAprovacao = 100;
				projetoCurso.periodicidadeUID = null;
				projetoCurso.nomeCursoModular = string.Empty;
				projetoCurso.cargaHorariaModular = null;
				projetoCurso.cargaHorariaDiario = null;
				projetoCurso.turnoOfertaUID = null;
			}
			if (projetoCurso.realizacaoDataInicio > projetoCurso.realizacaoDataTermino)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "A data de início da realização do curso não pode ser posterior a data de término.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			return new ProjetoDAL().Salvar(projetoCurso);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Salvar os registros.", innerException);
		}
	}

	public ResultadoOperacao AlterarProjetoCurso(ProjetoCurso projetoCurso)
	{
		try
		{
			ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
			ProjetoDAL projetoDAL = new ProjetoDAL();
			if (projetoCurso.tipoModalidadeUID == 1)
			{
				projetoCurso.notaMinimaAprovacao = 7;
				projetoCurso.frequenciaMinimaAprovacao = 75;
				projetoCurso.descricaoAva = string.Empty;
			}
			if (projetoCurso.tipoModalidadeUID == 2)
			{
				projetoCurso.notaMinimaAprovacao = 7;
				projetoCurso.frequenciaMinimaAprovacao = 100;
				projetoCurso.periodicidadeUID = null;
				projetoCurso.nomeCursoModular = string.Empty;
				projetoCurso.cargaHorariaModular = null;
				projetoCurso.cargaHorariaDiario = null;
				projetoCurso.turnoOfertaUID = null;
			}
			if (projetoCurso.realizacaoDataInicio > projetoCurso.realizacaoDataTermino)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "A data de início da realização do curso não pode ser posterior a data de término.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			return projetoDAL.AlterarProjetoCurso(projetoCurso);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Salvar os registros.", innerException);
		}
	}

	public ProjetoCurso GetRegistroPorId(long projetoCursoUID)
	{
		try
		{
			return new ProjetoDAL().GetRegistroPorId(projetoCursoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível selecionar o registro.", innerException);
		}
	}

	public List<Especialidade> GetEspecialidadeEstruturaCurricular(long estruturaCurricularUID, int? numeroEspecialidade)
	{
		try
		{
			return new CursoDAL().GetEspecialidadeEstruturaCurricular(estruturaCurricularUID, numeroEspecialidade);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ViewUnidade BuscarUnidadeProponente(long proponenteUnidadeUID)
	{
		return new CursoDAL().BuscarUnidadeProponente(proponenteUnidadeUID);
	}
}

using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class CursoBO
{
	public List<ViewCurso> GetRegistros(long? servidorUID, string tipoServidor)
	{
		try
		{
			return new CursoDAL().GetRegistros(servidorUID, tipoServidor);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewCurso> FindRegistros(string registroAluno, long? servidorUID, string tipoServidor)
	{
		try
		{
			return new CursoDAL().FindRegistros(registroAluno, servidorUID, tipoServidor);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewCurso> GetCursoHomologado()
	{
		Contexto.GetContextInstance();
		try
		{
			return new CursoDAL().GetCursoHomologado();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewCurso> FindRegistrosHomologado(string criterio)
	{
		Contexto.GetContextInstance();
		try
		{
			return new CursoDAL().FindRegistrosHomologado(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CorrecaoCurso> GetDescricaoCorrecao(long cursoUID, byte tipoSolicitanteUID)
	{
		try
		{
			return new CursoDAL().GetDescricaoCorrecao(cursoUID, tipoSolicitanteUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Excluir(int id)
	{
		try
		{
			return new CursoDAL().Excluir(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível excluir os registros.", innerException);
		}
	}

	public ResultadoOperacao Salvar(Curso obj, long coordenadorUID, long viceCoordenadorUID, DateTime? dataInicioInscricao, DateTime? dataFimInscricao, DateTime? dataIncioEstrutura, DateTime? dataFimEstrutura)
	{
		try
		{
			return new CursoDAL().Salvar(obj, coordenadorUID, viceCoordenadorUID, dataInicioInscricao, dataFimInscricao, dataIncioEstrutura, dataFimEstrutura);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Salvar os registros.", innerException);
		}
	}

	public ResultadoOperacao Homologar(long cursoUID, string descricaoCorrecao, DateTime dataHoraUltimaAtualizacao, byte? tipoSolicitanteCorrecaoCursoUID)
	{
		try
		{
			return new CursoDAL().Homologar(cursoUID, descricaoCorrecao, dataHoraUltimaAtualizacao, tipoSolicitanteCorrecaoCursoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Salvar os registros.", innerException);
		}
	}

	public ResultadoOperacao ConfirmarCorrecaoCurso(long cursoUID, byte? tipoSolicitanteCorrecaoCursoUID)
	{
		try
		{
			return new CursoDAL().ConfirmarCorrecaoCurso(cursoUID, tipoSolicitanteCorrecaoCursoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível Salvar os registros.", innerException);
		}
	}

	public ViewCurso GetRegistroPorId(long id)
	{
		try
		{
			return new CursoDAL().GetRegistroPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível selecionar o registro.", innerException);
		}
	}

	public CorrecaoCurso GetCorrecaoCurso(long cursoUID, long tipoSolicitanteCursoUID)
	{
		try
		{
			return new CursoDAL().GetCorrecaoCurso(cursoUID, tipoSolicitanteCursoUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível selecionar o registro.", innerException);
		}
	}

	public List<CorrecaoCurso> GetCorrecaoCurso(long cursoUID)
	{
		try
		{
			return new CursoDAL().GetCorrecaoCurso(cursoUID);
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
}

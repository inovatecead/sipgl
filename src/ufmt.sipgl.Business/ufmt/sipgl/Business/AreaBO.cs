using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class AreaBO
{
	public List<CNPqAreaConhecimento> GetRegistros()
	{
		try
		{
			return new AreaDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CNPqAreaConhecimento> FindRegistros(string criterio)
	{
		try
		{
			return new AreaDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public CNPqAreaConhecimento GetPorId(int id)
	{
		try
		{
			return new AreaDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public DetalheAreaConhecimento getDetalhesAreaConhecimento(long projetoCursoUID)
	{
		return new AreaDAL().getDetalhesAreaConhecimento(projetoCursoUID);
	}

	public List<CNPqAreaConhecimento> GetRegistros(long idSuperior)
	{
		try
		{
			return new AreaDAL().GetRegistros(idSuperior);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CNPqSubAreaConhecimento> GetRegistrosSubArea(long idSuperior)
	{
		try
		{
			return new AreaDAL().GetRegistrosSubArea(idSuperior);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<Especialidade> GetEspecialidade()
	{
		try
		{
			return new AreaDAL().GetArea();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<Especialidade> GetEspecialidadeEstruturaCurricular(long estruturaCurricularUID)
	{
		try
		{
			return new AreaDAL().GetEspecialidadeEstruturaCurricular(estruturaCurricularUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Salvar(Especialidade area)
	{
		try
		{
			return new AreaDAL().Salvar(area);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Excluir(long id)
	{
		try
		{
			return new AreaDAL().Excluir(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

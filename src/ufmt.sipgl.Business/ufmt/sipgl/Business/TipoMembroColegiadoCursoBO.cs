using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoMembroColegiadoCursoBO
{
	public List<TipoMembroColegiadoCurso> GetRegistros()
	{
		try
		{
			return new TipoMembroColegiadoCursoDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoMembroColegiadoCurso> FindRegistros(string criterio)
	{
		try
		{
			return new TipoMembroColegiadoCursoDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoMembroColegiadoCurso GetPorId(int id)
	{
		try
		{
			return new TipoMembroColegiadoCursoDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

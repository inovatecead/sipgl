using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoStatusBO
{
	public List<TipoStatusCurso> GetRegistros()
	{
		try
		{
			return new TipoStatusDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoStatusCurso> FindRegistros(string criterio)
	{
		try
		{
			return new TipoStatusDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoStatusCurso GetPorId(int id)
	{
		try
		{
			return new TipoStatusDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

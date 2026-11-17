using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoPassagemBO
{
	public List<TipoPassagem> GetRegistros()
	{
		try
		{
			return new TipoPassagemDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoPassagem> FindRegistros(string criterio)
	{
		try
		{
			return new TipoPassagemDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoPassagem GetPorId(int id)
	{
		try
		{
			return new TipoPassagemDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

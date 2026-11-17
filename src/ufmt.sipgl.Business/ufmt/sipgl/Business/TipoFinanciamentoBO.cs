using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoFinanciamentoBO
{
	public List<TipoFinanciamento> GetRegistros()
	{
		try
		{
			return new TipoFinanciamentoDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoFinanciamento> FindRegistros(string criterio)
	{
		try
		{
			return new TipoFinanciamentoDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoFinanciamento GetPorId(int id)
	{
		try
		{
			return new TipoFinanciamentoDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

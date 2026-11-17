using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoDespesaBO
{
	public List<TipoDespesa> GetRegistros()
	{
		try
		{
			return new TipoDespesaDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoDespesa> FindRegistros(string criterio)
	{
		try
		{
			return new TipoDespesaDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoDespesa GetPorId(int id)
	{
		try
		{
			return new TipoDespesaDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

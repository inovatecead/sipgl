using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoGestaoFinanceiraBO
{
	public List<TipoGestaoFinanceira> GetRegistros()
	{
		try
		{
			return new TipoGestaoFinanceiraDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoGestaoFinanceira> FindRegistros(string criterio)
	{
		try
		{
			return new TipoGestaoFinanceiraDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoGestaoFinanceira GetPorId(int id)
	{
		try
		{
			return new TipoGestaoFinanceiraDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

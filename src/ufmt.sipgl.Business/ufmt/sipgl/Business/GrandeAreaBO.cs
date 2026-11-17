using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class GrandeAreaBO
{
	public List<CNPqGrandeAreaConhecimento> GetRegistros()
	{
		try
		{
			return new GrandeAreaDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CNPqGrandeAreaConhecimento> FindRegistros(string criterio)
	{
		try
		{
			return new GrandeAreaDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public CNPqGrandeAreaConhecimento GetPorId(int id)
	{
		try
		{
			return new GrandeAreaDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

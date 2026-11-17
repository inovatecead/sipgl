using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class CampusBO
{
	public List<Campus> GetRegistros()
	{
		try
		{
			return new CampusDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<Campus> FindRegistros(string criterio)
	{
		try
		{
			return new CampusDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public Campus GetPorId(int id)
	{
		try
		{
			return new CampusDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

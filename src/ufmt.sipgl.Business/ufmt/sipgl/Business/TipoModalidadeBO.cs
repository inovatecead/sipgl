using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoModalidadeBO
{
	public List<TipoModalidade> GetRegistros()
	{
		try
		{
			return new TipoModalidadeDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoModalidade> FindRegistros(string criterio)
	{
		try
		{
			return new TipoModalidadeDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoModalidade GetPorId(int id)
	{
		try
		{
			return new TipoModalidadeDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

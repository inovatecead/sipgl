using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoAtividadeBO
{
	public List<TipoAtividade> GetRegistros()
	{
		try
		{
			return new TipoAtividadeDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoAtividade> FindRegistros(string criterio)
	{
		try
		{
			return new TipoAtividadeDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoAtividade GetPorId(int id)
	{
		try
		{
			return new TipoAtividadeDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

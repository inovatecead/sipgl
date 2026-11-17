using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoMaterialConsumoBO
{
	public List<TipoMaterialConsumo> GetRegistros()
	{
		try
		{
			return new TipoMaterialConsumoDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoMaterialConsumo> FindRegistros(string criterio)
	{
		try
		{
			return new TipoMaterialConsumoDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoMaterialConsumo GetPorId(int id)
	{
		try
		{
			return new TipoMaterialConsumoDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

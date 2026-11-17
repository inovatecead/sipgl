using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoMaterialPermanenteBO
{
	public List<TipoMaterialPermanente> GetRegistros()
	{
		try
		{
			return new TipoMaterialPermanenteDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoMaterialPermanente> FindRegistros(string criterio)
	{
		try
		{
			return new TipoMaterialPermanenteDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoMaterialPermanente GetPorId(int id)
	{
		try
		{
			return new TipoMaterialPermanenteDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

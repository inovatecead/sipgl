using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoMaterialConsumoDAL
{
	public List<TipoMaterialConsumo> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoMaterialConsumo.Select((TipoMaterialConsumo c) => c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoMaterialConsumo GetPorId(int id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoMaterialConsumo.Where((TipoMaterialConsumo c) => c.tipoMaterialConsumoUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<TipoMaterialConsumo> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoMaterialConsumo.Where((TipoMaterialConsumo c) => c.nome.Contains(criterio)).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

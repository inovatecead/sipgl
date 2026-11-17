using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoFinanciamentoDAL
{
	public List<TipoFinanciamento> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoFinanciamento.Select((TipoFinanciamento c) => c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoFinanciamento GetPorId(int id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoFinanciamento.Where((TipoFinanciamento c) => c.tipoFinanciamentoUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<TipoFinanciamento> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoFinanciamento.Where((TipoFinanciamento c) => c.nome.Contains(criterio)).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

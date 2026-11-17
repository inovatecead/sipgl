using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class GrandeAreaDAL
{
	public List<CNPqGrandeAreaConhecimento> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqGrandeAreaConhecimento.Select((CNPqGrandeAreaConhecimento c) => c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public CNPqGrandeAreaConhecimento GetPorId(int id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqGrandeAreaConhecimento.Where((CNPqGrandeAreaConhecimento c) => c.CNPqGrandeAreaConhecimentoUID == (long)id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<CNPqGrandeAreaConhecimento> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqGrandeAreaConhecimento.Where((CNPqGrandeAreaConhecimento c) => c.nome.Contains(criterio)).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

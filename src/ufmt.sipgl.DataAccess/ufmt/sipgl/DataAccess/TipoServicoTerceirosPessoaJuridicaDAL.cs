using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoServicoTerceirosPessoaJuridicaDAL
{
	public List<TipoServicoTerceirosPessoaJuridica> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoServicoTerceirosPessoaJuridica.Select((TipoServicoTerceirosPessoaJuridica c) => c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoServicoTerceirosPessoaJuridica GetPorId(int id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoServicoTerceirosPessoaJuridica.Where((TipoServicoTerceirosPessoaJuridica c) => c.tipoServicoTerceirosPessoaJuridicaUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<TipoServicoTerceirosPessoaJuridica> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoServicoTerceirosPessoaJuridica.Where((TipoServicoTerceirosPessoaJuridica c) => c.nome.Contains(criterio)).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

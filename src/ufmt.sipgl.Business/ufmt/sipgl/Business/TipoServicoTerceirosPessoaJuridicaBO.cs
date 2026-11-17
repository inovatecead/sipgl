using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoServicoTerceirosPessoaJuridicaBO
{
	public List<TipoServicoTerceirosPessoaJuridica> GetRegistros()
	{
		try
		{
			return new TipoServicoTerceirosPessoaJuridicaDAL().GetRegistros();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoServicoTerceirosPessoaJuridica> FindRegistros(string criterio)
	{
		try
		{
			return new TipoServicoTerceirosPessoaJuridicaDAL().FindRegistros(criterio);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public TipoServicoTerceirosPessoaJuridica GetPorId(int id)
	{
		try
		{
			return new TipoServicoTerceirosPessoaJuridicaDAL().GetPorId(id);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

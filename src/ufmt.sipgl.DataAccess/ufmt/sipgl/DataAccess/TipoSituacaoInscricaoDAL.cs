using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoSituacaoInscricaoDAL
{
	public List<TipoSituacaoInscricao> ListarTipoSituacaoInscricao()
	{
		try
		{
			return Contexto.GetContextInstance().TipoSituacaoInscricao.ToList();
		}
		catch (Exception)
		{
			return new List<TipoSituacaoInscricao>();
		}
	}

	public TipoSituacaoInscricao BuscarTipoSituacaoInscricaoPorDescricao(string descricao)
	{
		try
		{
			return Contexto.GetContextInstance().TipoSituacaoInscricao.Where((TipoSituacaoInscricao e) => e.nome.ToUpper().Contains(descricao.ToUpper())).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}
}

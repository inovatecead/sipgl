using System.Collections.Generic;
using System.Linq;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoSituacaoInscricaoBO
{
	private TipoSituacaoInscricaoDAL tipoSituacaoInscricaoDAL { get; set; }

	public TipoSituacaoInscricaoBO()
	{
		tipoSituacaoInscricaoDAL = new TipoSituacaoInscricaoDAL();
	}

	public List<TipoSituacaoInscricao> ListaTipoSituacaoInscricao()
	{
		return tipoSituacaoInscricaoDAL.ListarTipoSituacaoInscricao();
	}

	public List<TipoSituacaoInscricao> ListaTipoSituacaoInscricaoFiltro()
	{
		return (from e in tipoSituacaoInscricaoDAL.ListarTipoSituacaoInscricao()
			where e.tipoSituacaoInscricaoUID != 1 && e.tipoSituacaoInscricaoUID != 2
			select e).ToList();
	}

	public TipoSituacaoInscricao BuscarTipoSituacaoInscricaoPorDescricao(string descricao)
	{
		return tipoSituacaoInscricaoDAL.BuscarTipoSituacaoInscricaoPorDescricao(descricao);
	}
}

using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class PermissaoBO
{
	private const long aplicacaoUID = 19L;

	public PermissaoDAL PermissaoDAL { get; set; }

	public PermissaoBO()
	{
		PermissaoDAL = new PermissaoDAL();
	}

	public Permissao BuscarPermissaoPorID(long permissaoUID)
	{
		return PermissaoDAL.BuscarPermissaoPorID(permissaoUID);
	}

	public List<Permissao> ListarPermissoesPorAplicacao()
	{
		return PermissaoDAL.ListarPermissoesPorAplicacao(19L);
	}

	public List<PermissaoUsuario> ListarPermissoesPorUsuario(long usuarioUID, bool isAtivas)
	{
		return PermissaoDAL.ListarPermissoesPorUsuario(usuarioUID, 19L, isAtivas);
	}

	public ResultadoOperacao VincularPermissoes(List<long> listaPermissoesSelecionadas, long usuarioUID)
	{
		return PermissaoDAL.VincularPermissoes(listaPermissoesSelecionadas, usuarioUID);
	}
}

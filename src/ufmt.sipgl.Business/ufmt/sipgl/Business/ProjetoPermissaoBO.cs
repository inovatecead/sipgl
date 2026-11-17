using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoPermissaoBO
{
	public ProjetoPermissaoDAL ProjetoPermissaoDAL { get; set; }

	public ProjetoPermissaoBO()
	{
		ProjetoPermissaoDAL = new ProjetoPermissaoDAL();
	}

	public List<Permissao> ListarPerfis()
	{
		return ProjetoPermissaoDAL.ListarPerfis();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class ProjetoPermissaoDAL
{
	public List<Permissao> ListarPerfis()
	{
		try
		{
			return (from e in Contexto.GetContextInstance().Permissao
				where e.aplicacaoUID == 19
				orderby e.nome
				select e).ToList();
		}
		catch (Exception)
		{
			return new List<Permissao>();
		}
	}
}

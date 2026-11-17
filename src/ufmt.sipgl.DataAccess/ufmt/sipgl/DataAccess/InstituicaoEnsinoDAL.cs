using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class InstituicaoEnsinoDAL
{
	public List<InstituicaoEnsino> BuscarInstituicaoEnsinoPorDescricao(string nome)
	{
		try
		{
			return Contexto.GetContextInstance().InstituicaoEnsino.Where((InstituicaoEnsino e) => e.nome.ToUpper().Contains(nome.ToUpper())).ToList();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public List<InstituicaoEnsino> ListarTodos()
	{
		try
		{
			return Contexto.GetContextInstance().InstituicaoEnsino.OrderBy((InstituicaoEnsino e) => e.nome).ToList();
		}
		catch (Exception)
		{
			return new List<InstituicaoEnsino>();
		}
	}
}

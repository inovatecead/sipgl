using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class InstituicaoEnsinoBO
{
	public InstituicaoEnsinoDAL InstituicaoEnsinoDAL { get; set; }

	public InstituicaoEnsinoBO()
	{
		InstituicaoEnsinoDAL = new InstituicaoEnsinoDAL();
	}

	public List<InstituicaoEnsino> ListarTodos()
	{
		return InstituicaoEnsinoDAL.ListarTodos();
	}

	public List<InstituicaoEnsino> BuscarInstituicaoEnsinoPorDescricao(string nome)
	{
		return InstituicaoEnsinoDAL.BuscarInstituicaoEnsinoPorDescricao(nome);
	}
}

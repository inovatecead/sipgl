using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoRecursoBO
{
	public ProjetoRecursoDAL ProjetoRecursoDAL { get; set; }

	public ProjetoRecursoBO()
	{
		ProjetoRecursoDAL = new ProjetoRecursoDAL();
	}

	public List<ProjetoRecurso> ListarRecursos()
	{
		return ProjetoRecursoDAL.ListarRecursos();
	}

	public List<ProjetoRecurso> ListarRecursosVinculados(long permissaoUID)
	{
		return ProjetoRecursoDAL.ListarRecursosVinculados(permissaoUID);
	}

	public bool IsRecursoVinculado(long projetoRecursoUID, long permissaoUID)
	{
		return ProjetoRecursoDAL.IsRecursoVinculado(projetoRecursoUID, permissaoUID);
	}

	public ResultadoOperacao VincularRecurso(long projetoRecursoUID, long permissaoUID)
	{
		return ProjetoRecursoDAL.VincularRecurso(projetoRecursoUID, permissaoUID);
	}

	public ResultadoOperacao DesvincularRecurso(long projetoRecursoUID, long permissaoUID)
	{
		return ProjetoRecursoDAL.DesvincularRecurso(projetoRecursoUID, permissaoUID);
	}

	public List<ProjetoRecurso> ListarRecursosPorPerfil(long permissaoUID)
	{
		return ProjetoRecursoDAL.ListarRecursosPorPerfil(permissaoUID);
	}

	public List<ProjetoRecurso> ListarRecursosPorPerfis(List<long> listaPermissaoUID)
	{
		return ProjetoRecursoDAL.ListarRecursosPorPerfis(listaPermissaoUID);
	}
}

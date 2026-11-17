using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoDisciplinaBO
{
	public ProjetoDisciplinaDAL projetoDisciplinaDAL { get; set; }

	public ProjetoDisciplinaBO()
	{
		projetoDisciplinaDAL = new ProjetoDisciplinaDAL();
	}

	public ProjetoDisciplina BuscarDisciplinaPorId(long projetoDisciplinaUID)
	{
		return projetoDisciplinaDAL.BuscarDisciplinaPorId(projetoDisciplinaUID);
	}

	public List<ProjetoDisciplina> ListarDisciplinasPorCurso(long projetoCursoUID)
	{
		return projetoDisciplinaDAL.ListarDisciplinasPorCurso(projetoCursoUID);
	}

	public List<ProjetoDisciplina> ListarDisciplinasPorCursoTurma(long projetoCursoUID, long projetoTurmaUID)
	{
		return projetoDisciplinaDAL.ListarDisciplinasPorCursoTurma(projetoCursoUID, projetoTurmaUID);
	}

	public List<ProjetoDisciplina> Filtrar(long projetoCursoUID, string nome)
	{
		return projetoDisciplinaDAL.Filtrar(projetoCursoUID, nome);
	}

	public ResultadoOperacao CadastrarDisciplina(ProjetoDisciplina projetoDisciplina)
	{
		return projetoDisciplinaDAL.CadastrarDisciplina(projetoDisciplina);
	}

	public ResultadoOperacao AlterarDisciplina(ProjetoDisciplina projetoDisciplina)
	{
		return projetoDisciplinaDAL.AlterarDisciplina(projetoDisciplina);
	}

	public ResultadoOperacao Excluir(long projetoDisciplinaUID)
	{
		return projetoDisciplinaDAL.Excluir(projetoDisciplinaUID);
	}
}

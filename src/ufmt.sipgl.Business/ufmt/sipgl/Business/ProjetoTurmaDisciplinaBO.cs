using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoTurmaDisciplinaBO
{
	private ProjetoTurmaDisciplinaDAL projetoTurmaDisciplinaDAL;

	public ProjetoTurmaDisciplinaBO()
	{
		projetoTurmaDisciplinaDAL = new ProjetoTurmaDisciplinaDAL();
	}

	public ResultadoOperacao VincularDocente(ProjetoTurmaDisciplina projetoTurmaDisciplina)
	{
		return projetoTurmaDisciplinaDAL.VincularDocente(projetoTurmaDisciplina);
	}

	public ProjetoTurmaDisciplina BuscarTurmaDisciplinaPorTurmaDisciplina(long projetoTurmaUID, long projetoDisciplinaUID)
	{
		return projetoTurmaDisciplinaDAL.BuscarTurmaDisciplinaPorTurmaDisciplina(projetoTurmaUID, projetoDisciplinaUID);
	}

	public ProjetoTurmaDisciplina BuscarTurmaDisciplinaPorId(long projetoTurmaDisciplinaUID)
	{
		return projetoTurmaDisciplinaDAL.BuscarTurmaDisciplinaPorId(projetoTurmaDisciplinaUID);
	}
}

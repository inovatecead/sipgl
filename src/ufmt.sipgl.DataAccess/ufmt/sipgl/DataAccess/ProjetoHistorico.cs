namespace ufmt.sipgl.DataAccess;

public class ProjetoHistorico
{
	public long historicoUID { get; set; }

	public long discenteUID { get; set; }

	public long turmaDisciplinaUID { get; set; }

	public byte situacaoHistoricoUID { get; set; }

	public decimal nota { get; set; }

	public short faltas { get; set; }

	public virtual ProjetoDiscente ProjetoDiscente { get; set; }

	public virtual ProjetoTurmaDisciplina ProjetoTurmaDisciplina { get; set; }
}

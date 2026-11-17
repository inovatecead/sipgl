namespace ufmt.sipgl.DataAccess;

public class Historico
{
	public long historicoUID { get; set; }

	public long discenteUID { get; set; }

	public long turmaDisciplinaUID { get; set; }

	public byte situacaoHistoricoUID { get; set; }

	public decimal nota { get; set; }

	public short faltas { get; set; }

	public virtual Discente Discente { get; set; }

	public virtual TurmaDisciplina TurmaDisciplina { get; set; }
}

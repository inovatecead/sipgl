using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoNotaHistorico
{
	public long projetoNotaHistoricoUID { get; set; }

	public long projetoNotaUID { get; set; }

	public decimal? nota { get; set; }

	public string conceito { get; set; }

	public string descricaoTCC { get; set; }

	public long usuarioUID { get; set; }

	public DateTime? dataInclusao { get; set; }

	public DateTime? dataAlteracao { get; set; }

	public string ip { get; set; }

	public virtual ProjetoNota ProjetoNota { get; set; }

	public virtual Usuario Usuario { get; set; }
}

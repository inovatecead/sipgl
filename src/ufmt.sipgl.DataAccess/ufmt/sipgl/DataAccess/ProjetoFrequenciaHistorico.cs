using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoFrequenciaHistorico
{
	public long projetoFrequenciaHistoricoUID { get; set; }

	public long projetoFrequenciaUID { get; set; }

	public bool? isPresente { get; set; }

	public long usuarioUID { get; set; }

	public DateTime? dataInclusao { get; set; }

	public DateTime? dataAlteracao { get; set; }

	public string ip { get; set; }

	public virtual ProjetoFrequencia ProjetoFrequencia { get; set; }

	public virtual Usuario Usuario { get; set; }
}

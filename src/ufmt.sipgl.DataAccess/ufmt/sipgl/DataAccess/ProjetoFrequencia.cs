using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoFrequencia
{
	public long projetoFrequenciaUID { get; set; }

	public long preMatriculaInscricaoUID { get; set; }

	public long projetoEncontroPresencialUID { get; set; }

	public bool? isPresente { get; set; }

	public virtual ProjetoEncontroPresencial ProjetoEncontroPresencial { get; set; }

	public virtual PreMatriculaInscricao PreMatriculaInscricao { get; set; }

	public virtual ICollection<ProjetoFrequenciaHistorico> ProjetoFrequenciaHistorico { get; set; }

	public ProjetoFrequencia()
	{
		ProjetoFrequenciaHistorico = new HashSet<ProjetoFrequenciaHistorico>();
	}
}

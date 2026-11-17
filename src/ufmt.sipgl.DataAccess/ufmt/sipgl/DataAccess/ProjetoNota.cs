using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoNota
{
	public long projetoNotaUID { get; set; }

	public long preMatriculaInscricaoUID { get; set; }

	public long projetoDisciplinaUID { get; set; }

	public decimal? nota { get; set; }

	public string conceito { get; set; }

	public string descricaoTCC { get; set; }

	public virtual PreMatriculaInscricao PreMatriculaInscricao { get; set; }

	public virtual ProjetoDisciplina ProjetoDisciplina { get; set; }

	public virtual ICollection<ProjetoNotaHistorico> ProjetoNotaHistorico { get; set; }

	public ProjetoNota()
	{
		ProjetoNotaHistorico = new HashSet<ProjetoNotaHistorico>();
	}
}

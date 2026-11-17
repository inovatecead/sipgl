using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoPeriodoIngresso
{
	public byte tipoPeriodoIngressoUID { get; set; }

	public byte periodo { get; set; }

	public string sigla { get; set; }

	public string regime { get; set; }

	public virtual ICollection<Discente> Discente { get; set; }

	public virtual ICollection<ProjetoDiscente> ProjetoDiscente { get; set; }

	public virtual ICollection<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public TipoPeriodoIngresso()
	{
		Discente = new HashSet<Discente>();
		ProjetoDiscente = new HashSet<ProjetoDiscente>();
		PreMatriculaInscricaoOcorrencia = new HashSet<PreMatriculaInscricaoOcorrencia>();
	}
}

using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoFormaIngresso
{
	public byte tipoFormaIngressoUID { get; set; }

	public string sigla { get; set; }

	public string nome { get; set; }

	public virtual ICollection<Discente> Discente { get; set; }

	public virtual ICollection<ProjetoDiscente> ProjetoDiscente { get; set; }

	public virtual ICollection<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public TipoFormaIngresso()
	{
		Discente = new HashSet<Discente>();
		ProjetoDiscente = new HashSet<ProjetoDiscente>();
		PreMatriculaInscricaoOcorrencia = new HashSet<PreMatriculaInscricaoOcorrencia>();
	}
}

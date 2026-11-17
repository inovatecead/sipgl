using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoReservaVagas
{
	public byte tipoReservaVagasUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<Discente> Discente { get; set; }

	public virtual ICollection<ProjetoDiscente> ProjetoDiscente { get; set; }

	public virtual ICollection<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public TipoReservaVagas()
	{
		Discente = new HashSet<Discente>();
		ProjetoDiscente = new HashSet<ProjetoDiscente>();
		PreMatriculaInscricaoOcorrencia = new HashSet<PreMatriculaInscricaoOcorrencia>();
	}
}

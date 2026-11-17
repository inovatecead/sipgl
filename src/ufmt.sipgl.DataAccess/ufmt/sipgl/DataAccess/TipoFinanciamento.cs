using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoFinanciamento
{
	public byte tipoFinanciamentoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public TipoFinanciamento()
	{
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}

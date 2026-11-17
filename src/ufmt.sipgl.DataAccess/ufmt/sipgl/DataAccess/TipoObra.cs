using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoObra
{
	public short tipoObraUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoObras> ProjetoObras { get; set; }

	public TipoObra()
	{
		ProjetoObras = new HashSet<ProjetoObras>();
	}
}

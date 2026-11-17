using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoReceita
{
	public short tipoReceitaUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoPrevisaoReceitas> ProjetoPrevisaoReceitas { get; set; }

	public TipoReceita()
	{
		ProjetoPrevisaoReceitas = new HashSet<ProjetoPrevisaoReceitas>();
	}
}

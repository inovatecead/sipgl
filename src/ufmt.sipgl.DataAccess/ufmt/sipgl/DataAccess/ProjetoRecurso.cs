using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoRecurso
{
	public long projetoRecursoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoPermissaoRecurso> ProjetoPermissaoRecurso { get; set; }

	public ProjetoRecurso()
	{
		ProjetoPermissaoRecurso = new HashSet<ProjetoPermissaoRecurso>();
	}
}

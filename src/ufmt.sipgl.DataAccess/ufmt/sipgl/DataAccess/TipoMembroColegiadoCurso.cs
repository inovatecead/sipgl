using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoMembroColegiadoCurso
{
	public byte tipoMembroColegiadoCursoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoColegiadoCurso> ProjetoColegiadoCurso { get; set; }

	public TipoMembroColegiadoCurso()
	{
		ProjetoColegiadoCurso = new HashSet<ProjetoColegiadoCurso>();
	}
}

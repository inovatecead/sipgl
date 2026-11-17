using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoStatusCurso
{
	public byte tipoStatusCursoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<Curso> Curso { get; set; }

	public TipoStatusCurso()
	{
		Curso = new HashSet<Curso>();
	}
}

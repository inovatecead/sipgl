using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoStatusHomologacao
{
	public byte tipoStatusHomologacaoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<Curso> Curso { get; set; }

	public TipoStatusHomologacao()
	{
		Curso = new HashSet<Curso>();
	}
}

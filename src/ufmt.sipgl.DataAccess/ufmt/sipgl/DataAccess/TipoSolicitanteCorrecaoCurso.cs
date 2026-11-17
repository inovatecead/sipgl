using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoSolicitanteCorrecaoCurso
{
	public byte tipoSolicitanteCorrecaoCursoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<CorrecaoCurso> CorrecaoCurso { get; set; }

	public TipoSolicitanteCorrecaoCurso()
	{
		CorrecaoCurso = new HashSet<CorrecaoCurso>();
	}
}

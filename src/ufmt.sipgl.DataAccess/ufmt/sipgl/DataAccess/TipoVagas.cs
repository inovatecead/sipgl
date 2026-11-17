using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoVagas
{
	public byte tipoVagasUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoCursoVagas> ProjetoCursoVagas { get; set; }

	public TipoVagas()
	{
		ProjetoCursoVagas = new HashSet<ProjetoCursoVagas>();
	}
}

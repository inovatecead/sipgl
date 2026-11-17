using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoVagas
{
	public long projetoCursoVagasUID { get; set; }

	public short numeroVagas { get; set; }

	public byte tipoVagasUID { get; set; }

	public virtual ICollection<ProjetoCursoComplementoEadVagas> ProjetoCursoComplementoEadVagas { get; set; }

	public virtual ICollection<ProjetoCursoComplementoPresencialVagas> ProjetoCursoComplementoPresencialVagas { get; set; }

	public virtual TipoVagas TipoVagas { get; set; }

	public ProjetoCursoVagas()
	{
		ProjetoCursoComplementoEadVagas = new HashSet<ProjetoCursoComplementoEadVagas>();
		ProjetoCursoComplementoPresencialVagas = new HashSet<ProjetoCursoComplementoPresencialVagas>();
	}
}

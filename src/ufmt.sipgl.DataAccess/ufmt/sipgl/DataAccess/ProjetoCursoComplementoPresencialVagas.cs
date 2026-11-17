namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoComplementoPresencialVagas
{
	public long projetoCursoComplementoPresencialVagasUID { get; set; }

	public long projetoCursoComplementoPresencialUID { get; set; }

	public long projetoCursoVagasUID { get; set; }

	public virtual ProjetoCursoComplementoPresencial ProjetoCursoComplementoPresencial { get; set; }

	public virtual ProjetoCursoVagas ProjetoCursoVagas { get; set; }
}

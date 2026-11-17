namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoComplementoEadVagas
{
	public long projetoCursoComplementoEadVagasUID { get; set; }

	public long projetoCursoComplementoEadUID { get; set; }

	public long projetoCursoVagasUID { get; set; }

	public long poloEadEnderecoUID { get; set; }

	public virtual ProjetoCursoComplementoEad ProjetoCursoComplementoEad { get; set; }

	public virtual ProjetoCursoVagas ProjetoCursoVagas { get; set; }
}

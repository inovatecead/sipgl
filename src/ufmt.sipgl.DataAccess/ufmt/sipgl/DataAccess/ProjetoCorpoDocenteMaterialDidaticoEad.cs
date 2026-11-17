namespace ufmt.sipgl.DataAccess;

public class ProjetoCorpoDocenteMaterialDidaticoEad
{
	public long projetoCorpoDocenteMaterialDidaticoEadUID { get; set; }

	public long projetoCursoComplementoEadUID { get; set; }

	public long servidorUID { get; set; }

	public long projetoDisciplinaUID { get; set; }

	public string descricaoMaterial { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }

	public virtual ProjetoCursoComplementoEad ProjetoCursoComplementoEad { get; set; }

	public virtual ProjetoDisciplina ProjetoDisciplina { get; set; }
}

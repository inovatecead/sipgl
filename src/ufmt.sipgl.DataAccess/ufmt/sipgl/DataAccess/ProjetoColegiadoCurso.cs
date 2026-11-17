namespace ufmt.sipgl.DataAccess;

public class ProjetoColegiadoCurso
{
	public long projetoColegiadoCursoUID { get; set; }

	public long? projetoCursoUID { get; set; }

	public long servidorUID { get; set; }

	public byte tipoMembroColegiadoUID { get; set; }

	public virtual TipoMembroColegiadoCurso TipoMembroColegiadoCurso { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

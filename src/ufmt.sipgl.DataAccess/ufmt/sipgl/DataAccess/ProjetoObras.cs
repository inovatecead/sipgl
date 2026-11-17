namespace ufmt.sipgl.DataAccess;

public class ProjetoObras
{
	public long projetoObrasUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoObraUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoObra TipoObra { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

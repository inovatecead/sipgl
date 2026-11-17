namespace ufmt.sipgl.DataAccess;

public class ProjetoInstalacao
{
	public long projetoInstalacaoUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoInstalacaoUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoInstalacao TipoInstalacao { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

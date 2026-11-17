namespace ufmt.sipgl.DataAccess;

public class ProjetoPrevisaoReceitas
{
	public long projetoPrevisaoReceitasUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoReceitaUID { get; set; }

	public short numeroAlunos { get; set; }

	public short numeroParcelas { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoReceita TipoReceita { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

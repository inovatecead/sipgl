namespace ufmt.sipgl.DataAccess;

public class ProjetoPermissaoRecurso
{
	public long projetoPermissaoRecursoUID { get; set; }

	public long permissaoUID { get; set; }

	public long projetoRecursoUID { get; set; }

	public virtual Permissao Permissao { get; set; }

	public virtual ProjetoRecurso ProjetoRecurso { get; set; }
}

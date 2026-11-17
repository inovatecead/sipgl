namespace ufmt.sipgl.DataAccess;

public class ProjetoUsuarioUnidade
{
	public long projetoUsuarioUnidadeUID { get; set; }

	public long usuarioUID { get; set; }

	public long unidadeUID { get; set; }

	public virtual Usuario Usuario { get; set; }
}

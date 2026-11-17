namespace ufmt.sipgl.DataAccess;

public class ProjetoServicoTerceirosPessoJuridica
{
	public long projetoServicoTerceirosPessoJuridicaUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoServicoTerceirosPessoaJuridicaUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoServicoTerceirosPessoaJuridica TipoServicoTerceirosPessoaJuridica { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

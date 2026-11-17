namespace ufmt.sipgl.DataAccess;

public class ProjetoMaterialConsumo
{
	public long projetoMaterialConsumoUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoMaterialConsumoUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoMaterialConsumo TipoMaterialConsumo { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

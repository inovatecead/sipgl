namespace ufmt.sipgl.DataAccess;

public class ProjetoMaterialPermanente
{
	public long projetoMaterialPermanenteUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoMaterialPemanenteUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoMaterialPermanente TipoMaterialPermanente { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

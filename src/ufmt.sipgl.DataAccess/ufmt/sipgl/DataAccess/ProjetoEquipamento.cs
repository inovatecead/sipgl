namespace ufmt.sipgl.DataAccess;

public class ProjetoEquipamento
{
	public long projetoEquipamentoUID { get; set; }

	public long projetoCursoUID { get; set; }

	public short tipoEquipamentoUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoEquipamento TipoEquipamento { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

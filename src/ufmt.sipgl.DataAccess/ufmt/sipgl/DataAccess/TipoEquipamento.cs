using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoEquipamento
{
	public short tipoEquipamentoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoEquipamento> ProjetoEquipamento { get; set; }

	public TipoEquipamento()
	{
		ProjetoEquipamento = new HashSet<ProjetoEquipamento>();
	}
}

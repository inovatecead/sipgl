using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoMaterialConsumo
{
	public short tipoMaterialConsumoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoMaterialConsumo> ProjetoMaterialConsumo { get; set; }

	public TipoMaterialConsumo()
	{
		ProjetoMaterialConsumo = new HashSet<ProjetoMaterialConsumo>();
	}
}

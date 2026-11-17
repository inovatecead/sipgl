using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoMaterialPermanente
{
	public short tipoMaterialPermanenteUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoMaterialPermanente> ProjetoMaterialPermanente { get; set; }

	public TipoMaterialPermanente()
	{
		ProjetoMaterialPermanente = new HashSet<ProjetoMaterialPermanente>();
	}
}

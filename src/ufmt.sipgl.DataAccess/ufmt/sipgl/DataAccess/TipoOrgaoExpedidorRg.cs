using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoOrgaoExpedidorRg
{
	public short tipoOrgaoExpedidorRgUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoCorpoDocente> ProjetoCorpoDocente { get; set; }

	public TipoOrgaoExpedidorRg()
	{
		ProjetoCorpoDocente = new HashSet<ProjetoCorpoDocente>();
	}
}

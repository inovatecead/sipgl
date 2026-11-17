using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoPassagem
{
	public byte tipoPassagemUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoPassagens> ProjetoPassagens { get; set; }

	public TipoPassagem()
	{
		ProjetoPassagens = new HashSet<ProjetoPassagens>();
	}
}

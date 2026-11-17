using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoCoordenador
{
	public byte tipoCoordenadorUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<Coordenador> Coordenador { get; set; }

	public TipoCoordenador()
	{
		Coordenador = new HashSet<Coordenador>();
	}
}

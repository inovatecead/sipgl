using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoDespesa
{
	public short tipoDespesaUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoDespesas> ProjetoDespesas { get; set; }

	public TipoDespesa()
	{
		ProjetoDespesas = new HashSet<ProjetoDespesas>();
	}
}

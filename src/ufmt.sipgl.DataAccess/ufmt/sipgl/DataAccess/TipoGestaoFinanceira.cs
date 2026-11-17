using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoGestaoFinanceira
{
	public byte tipoGestaoFinanceiraUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public TipoGestaoFinanceira()
	{
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}

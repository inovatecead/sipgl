using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoCorRaca
{
	public byte tipoCorRacaUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public TipoCorRaca()
	{
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
	}
}

using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoEstadoCivil
{
	public byte tipoEstadoCivilUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public TipoEstadoCivil()
	{
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
	}
}

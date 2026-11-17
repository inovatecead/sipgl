using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Pais
{
	public string paisUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public Pais()
	{
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
	}
}

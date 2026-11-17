using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoEspecialidade
{
	public string tipoEspecialidadeUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<Especialidade> Especialidade { get; set; }

	public TipoEspecialidade()
	{
		Especialidade = new HashSet<Especialidade>();
	}
}

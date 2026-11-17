using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Docencia
{
	public long docenciaUID { get; set; }

	public long servidorUID { get; set; }

	public virtual ICollection<TurmaDisciplina> TurmaDisciplina { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }

	public Docencia()
	{
		TurmaDisciplina = new HashSet<TurmaDisciplina>();
	}
}

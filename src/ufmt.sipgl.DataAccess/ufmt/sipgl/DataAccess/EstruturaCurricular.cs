using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class EstruturaCurricular
{
	public long estruturaCurricularUID { get; set; }

	public long cursoUID { get; set; }

	public DateTime? dataInicio { get; set; }

	public DateTime? dataFim { get; set; }

	public virtual Curso Curso { get; set; }

	public virtual ICollection<Especialidade> Especialidade { get; set; }

	public EstruturaCurricular()
	{
		Especialidade = new HashSet<Especialidade>();
	}
}

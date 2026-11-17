using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TurmaDisciplina
{
	public long turmaDisciplinaUID { get; set; }

	public long turmaUID { get; set; }

	public long disciplinaUID { get; set; }

	public long docenciaUID { get; set; }

	public virtual Disciplina Disciplina { get; set; }

	public virtual Docencia Docencia { get; set; }

	public virtual ICollection<Historico> Historico { get; set; }

	public virtual ICollection<Horario> Horario { get; set; }

	public TurmaDisciplina()
	{
		Historico = new HashSet<Historico>();
		Horario = new HashSet<Horario>();
	}
}

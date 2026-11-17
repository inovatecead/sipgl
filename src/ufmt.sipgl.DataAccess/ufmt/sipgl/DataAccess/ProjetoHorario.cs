using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoHorario
{
	public long horarioUID { get; set; }

	public DateTime data { get; set; }

	public TimeSpan horaInicio { get; set; }

	public TimeSpan horaFim { get; set; }

	public long turmaDisciplinaUID { get; set; }

	public virtual ProjetoTurmaDisciplina ProjetoTurmaDisciplina { get; set; }
}

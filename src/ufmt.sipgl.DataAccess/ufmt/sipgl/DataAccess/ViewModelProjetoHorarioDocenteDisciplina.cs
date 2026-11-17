using System;

namespace ufmt.sipgl.DataAccess;

public class ViewModelProjetoHorarioDocenteDisciplina
{
	public long ProjetoDisciplinaUID { get; set; }

	public long ProjetoHorarioUID { get; set; }

	public long TurmaDisciplinaUID { get; set; }

	public long TurmaUID { get; set; }

	public DateTime Data { get; set; }

	public TimeSpan HoraInicio { get; set; }

	public TimeSpan HoraFim { get; set; }

	public string NomeDisciplina { get; set; }

	public string NomeDocente { get; set; }
}

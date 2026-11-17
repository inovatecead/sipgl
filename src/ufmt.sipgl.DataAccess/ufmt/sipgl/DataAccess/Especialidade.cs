using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Especialidade
{
	public long especialidadeUID { get; set; }

	public long estruturaCurricularUID { get; set; }

	public string tipoEspecialidadeUID { get; set; }

	public string nome { get; set; }

	public DateTime dataHoraCadastro { get; set; }

	public DateTime? dataHoraExclusao { get; set; }

	public bool excluida { get; set; }

	public virtual ICollection<Discente> Discente { get; set; }

	public virtual EstruturaCurricular EstruturaCurricular { get; set; }

	public virtual TipoEspecialidade TipoEspecialidade { get; set; }

	public virtual ICollection<EspecialidadeDisciplina> EspecialidadeDisciplina { get; set; }

	public Especialidade()
	{
		Discente = new HashSet<Discente>();
		EspecialidadeDisciplina = new HashSet<EspecialidadeDisciplina>();
	}
}

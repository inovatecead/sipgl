using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Disciplina
{
	public long disciplinaUID { get; set; }

	public string nome { get; set; }

	public string sigla { get; set; }

	public decimal cargaHorariaTeorica { get; set; }

	public decimal cargaHorariaPratica { get; set; }

	public decimal cargaHorariaSemanal { get; set; }

	public decimal cargaHorariaTotal { get; set; }

	public virtual ICollection<EspecialidadeDisciplina> EspecialidadeDisciplina { get; set; }

	public virtual ICollection<TurmaDisciplina> TurmaDisciplina { get; set; }

	public Disciplina()
	{
		EspecialidadeDisciplina = new HashSet<EspecialidadeDisciplina>();
		TurmaDisciplina = new HashSet<TurmaDisciplina>();
	}
}

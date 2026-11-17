using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoEncontroPresencial
{
	public long projetoEncontroPresencialUID { get; set; }

	public long projetoDisciplinaUID { get; set; }

	public long projetoTurmaPoloUID { get; set; }

	public DateTime dataEncontro { get; set; }

	public bool isObrigatorio { get; set; }

	public virtual ProjetoTurmaPolo ProjetoTurmaPolo { get; set; }

	public virtual ICollection<ProjetoFrequencia> ProjetoFrequencia { get; set; }

	public virtual ProjetoDisciplina ProjetoDisciplina { get; set; }

	public ProjetoEncontroPresencial()
	{
		ProjetoFrequencia = new HashSet<ProjetoFrequencia>();
	}
}

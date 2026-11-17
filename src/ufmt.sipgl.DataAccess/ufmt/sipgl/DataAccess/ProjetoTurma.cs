using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTurma
{
	public long projetoTurmaUID { get; set; }

	public string nome { get; set; }

	public int ano { get; set; }

	public byte periodo { get; set; }

	public byte turno { get; set; }

	public long projetoCursoUID { get; set; }

	public DateTime? DataInicio { get; set; }

	public DateTime? DataFim { get; set; }

	public bool isAtivo { get; set; }

	public virtual ICollection<ProjetoTurmaDisciplina> ProjetoTurmaDisciplina { get; set; }

	public virtual ICollection<ProjetoTurmaPolo> ProjetoTurmaPolo { get; set; }

	public virtual ICollection<ProjetoPreInscricao> ProjetoPreInscricao { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }

	public ProjetoTurma()
	{
		ProjetoTurmaDisciplina = new HashSet<ProjetoTurmaDisciplina>();
		ProjetoTurmaPolo = new HashSet<ProjetoTurmaPolo>();
		ProjetoPreInscricao = new HashSet<ProjetoPreInscricao>();
	}
}

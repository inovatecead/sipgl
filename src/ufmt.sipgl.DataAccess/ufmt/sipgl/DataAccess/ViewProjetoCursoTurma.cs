using System;

namespace ufmt.sipgl.DataAccess;

public class ViewProjetoCursoTurma
{
	public long projetoCursoUID { get; set; }

	public string nomeCurso { get; set; }

	public long projetoTurmaUID { get; set; }

	public string descricaoTurma { get; set; }

	public DateTime? dataInicioTurma { get; set; }

	public DateTime? dataFimTurma { get; set; }

	public bool isTurmaAtiva { get; set; }
}

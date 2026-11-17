using System;

namespace ufmt.sipgl.DataAccess;

public class ControleRegistroDiscente
{
	public long controleRegistroDiscenteUID { get; set; }

	public int codigoCurso { get; set; }

	public long numeroRegistroAtual { get; set; }

	public DateTime dataHoraCriacao { get; set; }
}

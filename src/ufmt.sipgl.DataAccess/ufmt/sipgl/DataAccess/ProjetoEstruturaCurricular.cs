using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoEstruturaCurricular
{
	public long estruturaCurricularUID { get; set; }

	public long cursoUID { get; set; }

	public DateTime? dataInicio { get; set; }

	public DateTime? dataFim { get; set; }
}

using System;

namespace ufmt.sipgl.DataAccess;

public class ProcedureObterCoordenadorCurso_Result
{
	public long usuarioUID { get; set; }

	public string Nome { get; set; }

	public string Permissao { get; set; }

	public long pessoaUID { get; set; }

	public string mail { get; set; }

	public DateTime? dataLimite { get; set; }
}

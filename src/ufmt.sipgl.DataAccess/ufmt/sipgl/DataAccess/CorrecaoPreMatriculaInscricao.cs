using System;

namespace ufmt.sipgl.DataAccess;

public class CorrecaoPreMatriculaInscricao
{
	public long correcaoPreMatriculaInscricaoUID { get; set; }

	public long preMatriculaInscricaoUID { get; set; }

	public long responsavelServidorUID { get; set; }

	public string descricao { get; set; }

	public DateTime dataHora { get; set; }

	public bool correcaoConfirmada { get; set; }

	public DateTime? dataHoraConfirmacaoCorrecao { get; set; }

	public virtual PreMatriculaInscricao PreMatriculaInscricao { get; set; }
}

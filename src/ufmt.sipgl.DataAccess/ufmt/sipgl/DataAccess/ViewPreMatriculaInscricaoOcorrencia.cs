using System;

namespace ufmt.sipgl.DataAccess;

public class ViewPreMatriculaInscricaoOcorrencia
{
	public long preMatriculaPessoaUID { get; set; }

	public string nome { get; set; }

	public long preMatriculaInscricaoUID { get; set; }

	public long preMatriculaIncricaoOcorrenciaUID { get; set; }

	public DateTime dataHoraOcorrencia { get; set; }

	public string observacao { get; set; }

	public string tipoSituacaoInscricao { get; set; }

	public string usuario { get; set; }
}

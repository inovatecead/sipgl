using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoSituacaoInscricao
{
	public byte tipoSituacaoInscricaoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<PreMatriculaInscricao> PreMatriculaInscricao { get; set; }

	public virtual ICollection<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public TipoSituacaoInscricao()
	{
		PreMatriculaInscricao = new HashSet<PreMatriculaInscricao>();
		PreMatriculaInscricaoOcorrencia = new HashSet<PreMatriculaInscricaoOcorrencia>();
	}
}

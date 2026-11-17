using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class PreMatriculaInscricao
{
	public long preMatriculaInscricaoUID { get; set; }

	public long preMatriculaPessoaUID { get; set; }

	public long numeroInscricao { get; set; }

	public byte tipoSituacaoInscricaoUID { get; set; }

	public long? projetoCursoUID { get; set; }

	public long? projetoTurmaPoloUID { get; set; }

	public virtual ICollection<CorrecaoPreMatriculaInscricao> CorrecaoPreMatriculaInscricao { get; set; }

	public virtual TipoSituacaoInscricao TipoSituacaoInscricao { get; set; }

	public virtual ProjetoTurmaPolo ProjetoTurmaPolo { get; set; }

	public virtual ICollection<ProjetoDiscente> ProjetoDiscente { get; set; }

	public virtual ICollection<ProjetoFrequencia> ProjetoFrequencia { get; set; }

	public virtual ICollection<ProjetoNota> ProjetoNota { get; set; }

	public virtual ICollection<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public virtual ICollection<ProjetoPreInscricao> ProjetoPreInscricao { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }

	public virtual PreMatriculaPessoa PreMatriculaPessoa { get; set; }

	public PreMatriculaInscricao()
	{
		CorrecaoPreMatriculaInscricao = new HashSet<CorrecaoPreMatriculaInscricao>();
		ProjetoDiscente = new HashSet<ProjetoDiscente>();
		ProjetoFrequencia = new HashSet<ProjetoFrequencia>();
		ProjetoNota = new HashSet<ProjetoNota>();
		PreMatriculaInscricaoOcorrencia = new HashSet<PreMatriculaInscricaoOcorrencia>();
		ProjetoPreInscricao = new HashSet<ProjetoPreInscricao>();
	}
}

using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoPreInscricao
{
	public long projetoPreInscricaoUID { get; set; }

	public long preMatriculaPessoaUID { get; set; }

	public int situacaoPreInscricaoEnum { get; set; }

	public long projetoTurmaUID { get; set; }

	public DateTime dataSolicitacao { get; set; }

	public long? preMatriculaInscricaoUID { get; set; }

	public DateTime? dataAtuacao { get; set; }

	public long? usuarioAtuacaoUID { get; set; }

	public string ipUsuarioAtuacao { get; set; }

	public virtual PreMatriculaInscricao PreMatriculaInscricao { get; set; }

	public virtual ProjetoTurma ProjetoTurma { get; set; }

	public virtual Usuario Usuario { get; set; }

	public virtual PreMatriculaPessoa PreMatriculaPessoa { get; set; }
}

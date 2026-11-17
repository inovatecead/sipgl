using System;

namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class PreInscricaoDTO
{
	public long ProjetoCursoUID { get; set; }

	public long ProjetoTurmaUID { get; set; }

	public long? PreMatriculaInscricaoUID { get; set; }

	public long PreMatriculaPessoaUID { get; set; }

	public string NomeCurso { get; set; }

	public string DescricaoTurma { get; set; }

	public DateTime? DataInicioTurma { get; set; }

	public DateTime? DataFimTurma { get; set; }

	public EnumSituacaoPreInscricao? EnumSituacaoPreInscricao { get; set; }

	public string DescricaoSituacaoEnum { get; set; }

	public DateTime DataSolicitacao { get; set; }

	public DateTime? DataAtuacao { get; set; }
}

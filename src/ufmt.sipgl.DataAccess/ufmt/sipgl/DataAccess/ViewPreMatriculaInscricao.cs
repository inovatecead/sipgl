using System;

namespace ufmt.sipgl.DataAccess;

public class ViewPreMatriculaInscricao
{
	public long preMatriculaInscricaoUID { get; set; }

	public long preMatriculaPessoaUID { get; set; }

	public long numeroInscricao { get; set; }

	public string pessoaNome { get; set; }

	public string cpf { get; set; }

	public string email { get; set; }

	public DateTime dataHoraUltimaAtualizacao { get; set; }

	public byte tipoSituacaoInscricaoUID { get; set; }

	public string tipoSituacaoInscricaoNome { get; set; }

	public long? discenteUID { get; set; }

	public string RGA { get; set; }

	public long projetoTurmaUID { get; set; }

	public string descricaoTurma { get; set; }

	public bool isTurmaAtiva { get; set; }

	public DateTime? projetoTurmaDataInicio { get; set; }

	public DateTime? projetoTurmaDataFim { get; set; }

	public long projetoTurmaPoloUID { get; set; }

	public int quantidadeVagas { get; set; }

	public long projetoCursoUID { get; set; }

	public string cursoNome { get; set; }

	public string municipio { get; set; }

	public int enderecoUID { get; set; }

	public string identificacaoEndereco { get; set; }
}

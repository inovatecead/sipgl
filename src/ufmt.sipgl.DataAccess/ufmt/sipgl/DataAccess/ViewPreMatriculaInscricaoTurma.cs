namespace ufmt.sipgl.DataAccess;

public class ViewPreMatriculaInscricaoTurma
{
	public long preMatriculaInscricaoUID { get; set; }

	public long preMatriculaPessoaUID { get; set; }

	public long? projetoDiscenteUID { get; set; }

	public string RGA { get; set; }

	public string nome { get; set; }

	public string CPF { get; set; }

	public string email { get; set; }

	public string tipoSituacaoInscricao { get; set; }

	public byte tipoSituacaoInscricaoUID { get; set; }

	public long projetoTurmaPoloUID { get; set; }

	public int enderecoUID { get; set; }

	public long projetoTurmaUID { get; set; }

	public string identificacaoEndereco { get; set; }
}

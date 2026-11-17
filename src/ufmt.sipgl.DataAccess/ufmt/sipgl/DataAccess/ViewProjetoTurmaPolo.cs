namespace ufmt.sipgl.DataAccess;

public class ViewProjetoTurmaPolo
{
	public string municipio { get; set; }

	public int? tipoUnidadeEnsino { get; set; }

	public string identificacaoEndereco { get; set; }

	public string bairroEndereco { get; set; }

	public string logradouro { get; set; }

	public long projetoTurmaUID { get; set; }

	public long projetoCursoUID { get; set; }

	public int enderecoUID { get; set; }

	public int quantidadeVagas { get; set; }
}

namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class PoloDTO
{
	public long ProjetoTurmaPoloUID { get; set; }

	public int EnderecoUID { get; set; }

	public string IdentificacaoEndereco { get; set; }

	public int TotalVagasPolo { get; set; }

	public int TotalAlunosMatriculados { get; set; }

	public int TotalAlunosAtivos { get; set; }

	public int TotalAlunosInativos { get; set; }

	public int TotalAlunosFormados { get; set; }
}

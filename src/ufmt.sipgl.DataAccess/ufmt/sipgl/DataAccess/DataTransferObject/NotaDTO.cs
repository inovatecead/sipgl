namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class NotaDTO
{
	public long ProjetoNotaUID { get; set; }

	public long PreMatriculaInscricaoUID { get; set; }

	public long ProjetoDisciplinaUID { get; set; }

	public long ProjetoTurmaUID { get; set; }

	public long EnderecoUID { get; set; }

	public string NomeDiscente { get; set; }

	public string TipoSituacaoInscricao { get; set; }

	public string CPF { get; set; }

	public decimal? Nota { get; set; }

	public string Conceito { get; set; }

	public string TituloTCC { get; set; }
}

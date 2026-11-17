namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class HistoricoEscolarDTO
{
	public long ProjetoDisciplinaUID { get; set; }

	public long ProjetoNotaUID { get; set; }

	public string NomeDisciplina { get; set; }

	public int CargaHoraria { get; set; }

	public string NomeDocente { get; set; }

	public string Titulacao { get; set; }

	public decimal? Nota { get; set; }

	public string Frequencia { get; set; }
}

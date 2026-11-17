namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class DisciplinaNotaDTO
{
	public long ProjetoDisciplinaUID { get; set; }

	public long ProjetoNotaUID { get; set; }

	public string NomeDisciplina { get; set; }

	public string NomeDocente { get; set; }

	public decimal? Nota { get; set; }
}

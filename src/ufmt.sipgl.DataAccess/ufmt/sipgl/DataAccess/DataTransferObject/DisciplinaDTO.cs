namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class DisciplinaDTO
{
	public long ProjetoDisciplinaUID { get; set; }

	public string Nome { get; set; }

	public short CargaHoraria { get; set; }

	public string DataInicio { get; set; }

	public string DataTermino { get; set; }

	public string NomeDocentePrincipal { get; set; }

	public string NomeDocenteSecundario { get; set; }
}

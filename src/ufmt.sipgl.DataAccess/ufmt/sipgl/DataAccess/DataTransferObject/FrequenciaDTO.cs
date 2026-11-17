namespace ufmt.sipgl.DataAccess.DataTransferObject;

public class FrequenciaDTO
{
	public long ProjetoFrequenciaUID { get; set; }

	public long PreMatriculaInscricaoUID { get; set; }

	public long ProjetoEncontroPresencialUID { get; set; }

	public string NomeDiscente { get; set; }

	public string TipoSituacaoInscricao { get; set; }

	public string CPF { get; set; }

	public bool? isPresente { get; set; }
}

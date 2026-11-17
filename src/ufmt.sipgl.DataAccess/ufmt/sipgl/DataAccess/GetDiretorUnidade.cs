namespace ufmt.sipgl.DataAccess;

public class GetDiretorUnidade
{
	public long pessoaUID { get; set; }

	public string NomeDiretoria { get; set; }

	public long unidadeUID { get; set; }

	public long? unidadeSuperiorUID { get; set; }

	public int campusUID { get; set; }
}

namespace ufmt.sipgl.DataAccess;

public class ProjetoBolsaEstagioLei_11788_2008
{
	public long projetoBolsaEstagioLei_11788_2008_UID { get; set; }

	public long projetoCursoUID { get; set; }

	public long pessoaUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

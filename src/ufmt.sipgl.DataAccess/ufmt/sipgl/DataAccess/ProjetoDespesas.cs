namespace ufmt.sipgl.DataAccess;

public class ProjetoDespesas
{
	public long projetoDespesasUID { get; set; }

	public long projetoCursoUID { get; set; }

	public long pessoaUID { get; set; }

	public short tipoDespesaUID { get; set; }

	public short quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoDespesa TipoDespesa { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

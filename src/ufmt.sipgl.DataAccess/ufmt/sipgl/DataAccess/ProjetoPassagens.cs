namespace ufmt.sipgl.DataAccess;

public class ProjetoPassagens
{
	public long projetoPassagensUID { get; set; }

	public long projetoCursoUID { get; set; }

	public long pessoaUID { get; set; }

	public byte tipoPassagemUID { get; set; }

	public string trecho { get; set; }

	public byte quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual TipoPassagem TipoPassagem { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

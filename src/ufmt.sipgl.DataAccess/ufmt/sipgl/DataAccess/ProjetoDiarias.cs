using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoDiarias
{
	public long projetoDiariasUID { get; set; }

	public long projetoCursoUID { get; set; }

	public long pessoaUID { get; set; }

	public int municipioUID { get; set; }

	public DateTime dataInicio { get; set; }

	public DateTime dataFim { get; set; }

	public decimal quantidade { get; set; }

	public decimal valorUnitario { get; set; }

	public virtual Municipio Municipio { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoPessoalEncargos
{
	public long projetoPessoalEncargosUID { get; set; }

	public long projetoCursoUID { get; set; }

	public long pessoaUID { get; set; }

	public byte tipoAtividadeUID { get; set; }

	public DateTime dataInicio { get; set; }

	public DateTime dataFim { get; set; }

	public decimal valorMensal { get; set; }

	public virtual TipoAtividade TipoAtividade { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

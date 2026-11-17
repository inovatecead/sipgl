using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoServicoTerceirosPessoaFisica
{
	public long projetoServicoTerceirosPessoaFisicaUID { get; set; }

	public long projetoCursoUID { get; set; }

	public long pessoaUID { get; set; }

	public bool atividadeNaoRegular { get; set; }

	public DateTime dataInicio { get; set; }

	public DateTime dataFim { get; set; }

	public short cargaHorariaMensal { get; set; }

	public short cargaHorariaTotal { get; set; }

	public decimal valorUnitarioCargaHoraria { get; set; }

	public decimal encargosSociais { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

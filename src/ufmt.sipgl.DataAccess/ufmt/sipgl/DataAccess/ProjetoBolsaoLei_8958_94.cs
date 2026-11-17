using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoBolsaoLei_8958_94
{
	public long projetoBolsaoLei_8958_94_UID { get; set; }

	public long projetoCursoUID { get; set; }

	public long servidorUID { get; set; }

	public bool atividadeNaoRegular { get; set; }

	public DateTime dataInicio { get; set; }

	public DateTime dataFim { get; set; }

	public short cargaHorariaMensal { get; set; }

	public short cargaHoraiaTotal { get; set; }

	public decimal valorUnitarioCargaHoraria { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }
}

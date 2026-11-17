using System;

namespace ufmt.sipgl.DataAccess;

public class Coordenador
{
	public long coordenadorUID { get; set; }

	public long cursoUID { get; set; }

	public long servidorUID { get; set; }

	public byte tipoCoordenadorUID { get; set; }

	public DateTime dataHoraCadastro { get; set; }

	public DateTime? dataHoraExclusao { get; set; }

	public bool ativo { get; set; }

	public virtual Curso Curso { get; set; }

	public virtual TipoCoordenador TipoCoordenador { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }
}

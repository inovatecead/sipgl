using System;

namespace ufmt.sipgl.DataAccess;

public class CorrecaoCursoMensagens
{
	public long correcaoCursoMensagensUID { get; set; }

	public long correcaoCursoUID { get; set; }

	public long responsavelServidorUID { get; set; }

	public string descricao { get; set; }

	public DateTime datahora { get; set; }

	public virtual CorrecaoCurso CorrecaoCurso { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }
}

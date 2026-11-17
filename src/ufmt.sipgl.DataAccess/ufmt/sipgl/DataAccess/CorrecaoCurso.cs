using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class CorrecaoCurso
{
	public long correcaoCursoUID { get; set; }

	public long cursoUID { get; set; }

	public byte tipoSolicitanteCorrecaoCursoUID { get; set; }

	public string descricao { get; set; }

	public DateTime dataHoraSolicitacaoCorrecao { get; set; }

	public bool correcaoConfirmada { get; set; }

	public DateTime? dataHoraConfirmacaoCorrecao { get; set; }

	public virtual Curso Curso { get; set; }

	public virtual TipoSolicitanteCorrecaoCurso TipoSolicitanteCorrecaoCurso { get; set; }

	public virtual ICollection<CorrecaoCursoMensagens> CorrecaoCursoMensagens { get; set; }

	public CorrecaoCurso()
	{
		CorrecaoCursoMensagens = new HashSet<CorrecaoCursoMensagens>();
	}
}

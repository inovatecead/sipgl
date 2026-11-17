using System;

namespace ufmt.sipgl.DataAccess;

public class PreMatriculaInscricaoOcorrencia
{
	public long preMatriculaIncricaoOcorrenciaUID { get; set; }

	public long preMatriculaInscricaoUID { get; set; }

	public byte tipoSituacaoInscricaoUID { get; set; }

	public DateTime dataHoraOcorrencia { get; set; }

	public string observacao { get; set; }

	public long? usuarioUID { get; set; }

	public byte? tipoFormaIngressoUID { get; set; }

	public DateTime? dataIngresso { get; set; }

	public byte? tipoPeriodoIngressoUID { get; set; }

	public byte? tipoReservaVagasUID { get; set; }

	public int? periodo { get; set; }

	public string ip { get; set; }

	public virtual PreMatriculaInscricao PreMatriculaInscricao { get; set; }

	public virtual TipoSituacaoInscricao TipoSituacaoInscricao { get; set; }

	public virtual TipoFormaIngresso TipoFormaIngresso { get; set; }

	public virtual TipoPeriodoIngresso TipoPeriodoIngresso { get; set; }

	public virtual TipoReservaVagas TipoReservaVagas { get; set; }

	public virtual Usuario Usuario { get; set; }
}

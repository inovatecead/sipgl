using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoDiscente
{
	public long discenteUID { get; set; }

	public string registro { get; set; }

	public byte tipoFormaIngressoUID { get; set; }

	public DateTime dataIngresso { get; set; }

	public byte tipoPeridoIngressoUID { get; set; }

	public byte tipoReservaVagasUID { get; set; }

	public long preMatriculaInscricaoUID { get; set; }

	public int periodo { get; set; }

	public virtual TipoFormaIngresso TipoFormaIngresso { get; set; }

	public virtual TipoPeriodoIngresso TipoPeriodoIngresso { get; set; }

	public virtual TipoReservaVagas TipoReservaVagas { get; set; }

	public virtual ICollection<ProjetoHistorico> ProjetoHistorico { get; set; }

	public virtual PreMatriculaInscricao PreMatriculaInscricao { get; set; }

	public ProjetoDiscente()
	{
		ProjetoHistorico = new HashSet<ProjetoHistorico>();
	}
}

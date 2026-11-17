using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Discente
{
	public long discenteUID { get; set; }

	public long pessoaUID { get; set; }

	public long registro { get; set; }

	public long especialidadeUID { get; set; }

	public byte tipoFormaIngressoUID { get; set; }

	public string dataIngresso { get; set; }

	public byte tipoPeridoIngressoUID { get; set; }

	public byte tipoReservaVagasUID { get; set; }

	public virtual Especialidade Especialidade { get; set; }

	public virtual TipoFormaIngresso TipoFormaIngresso { get; set; }

	public virtual TipoPeriodoIngresso TipoPeriodoIngresso { get; set; }

	public virtual TipoReservaVagas TipoReservaVagas { get; set; }

	public virtual ICollection<Historico> Historico { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public Discente()
	{
		Historico = new HashSet<Historico>();
	}
}

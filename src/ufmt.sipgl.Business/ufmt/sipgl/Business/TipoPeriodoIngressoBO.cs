using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoPeriodoIngressoBO
{
	public TipoPeriodoIngressoDAL TipoPeriodoIngressoDAL { get; set; }

	public TipoPeriodoIngressoBO()
	{
		TipoPeriodoIngressoDAL = new TipoPeriodoIngressoDAL();
	}

	public TipoPeriodoIngresso BuscarPorNome(string nome)
	{
		return TipoPeriodoIngressoDAL.BuscarPorNome(nome);
	}
}

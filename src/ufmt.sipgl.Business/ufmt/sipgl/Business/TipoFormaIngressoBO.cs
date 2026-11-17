using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoFormaIngressoBO
{
	public TipoFormaIngressoDAL TipoFormaIngressoDAL { get; set; }

	public TipoFormaIngressoBO()
	{
		TipoFormaIngressoDAL = new TipoFormaIngressoDAL();
	}

	public TipoFormaIngresso BuscarPorNome(string nome)
	{
		return TipoFormaIngressoDAL.BuscarPorNome(nome);
	}
}

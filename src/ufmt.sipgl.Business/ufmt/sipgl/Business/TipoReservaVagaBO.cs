using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class TipoReservaVagaBO
{
	public TipoReservaVagaDAL TipoReservaVagaDAL { get; set; }

	public TipoReservaVagaBO()
	{
		TipoReservaVagaDAL = new TipoReservaVagaDAL();
	}

	public TipoReservaVagas BuscarPorNome(string nome)
	{
		return TipoReservaVagaDAL.BuscarPorNome(nome);
	}
}

using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class PaisBO
{
	public PaisDAL PaisDAL { get; set; }

	public PaisBO()
	{
		PaisDAL = new PaisDAL();
	}

	public Pais BuscarPaisPorDescricao(string nome)
	{
		return PaisDAL.BuscarPaisPorDescricao(nome);
	}
}

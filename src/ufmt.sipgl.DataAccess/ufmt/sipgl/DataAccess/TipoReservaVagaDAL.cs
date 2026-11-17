using System;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoReservaVagaDAL
{
	public TipoReservaVagas BuscarPorNome(string nome)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoReservaVagas.Where((TipoReservaVagas e) => e.nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}
}

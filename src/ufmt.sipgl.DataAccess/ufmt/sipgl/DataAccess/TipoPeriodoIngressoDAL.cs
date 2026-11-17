using System;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoPeriodoIngressoDAL
{
	public TipoPeriodoIngresso BuscarPorNome(string nome)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoPeriodoIngresso.Where((TipoPeriodoIngresso e) => e.regime.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}
}

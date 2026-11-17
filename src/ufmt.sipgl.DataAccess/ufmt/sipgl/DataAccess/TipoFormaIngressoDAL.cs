using System;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class TipoFormaIngressoDAL
{
	public TipoFormaIngresso BuscarPorNome(string nome)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoFormaIngresso.Where((TipoFormaIngresso e) => e.nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}
}

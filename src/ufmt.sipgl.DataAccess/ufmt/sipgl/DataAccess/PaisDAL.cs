using System;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class PaisDAL
{
	public Pais BuscarPaisPorDescricao(string nome)
	{
		try
		{
			return Contexto.GetContextInstance().Pais.Where((Pais e) => e.nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}
}

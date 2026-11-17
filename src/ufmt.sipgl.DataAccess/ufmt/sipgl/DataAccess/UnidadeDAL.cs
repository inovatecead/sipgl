using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class UnidadeDAL
{
	public List<ViewUnidade> GetUnidade()
	{
		return Contexto.GetContextInstance().ViewUnidade.Select((ViewUnidade c) => c).ToList();
	}

	public List<ViewUnidade> GetUnidadesPorCampus(long campusUID)
	{
		return Contexto.GetContextInstance().ViewUnidade.Where((ViewUnidade c) => (long)c.campusUID == campusUID).ToList();
	}

	public List<ViewUnidade> GetUnidadesPorId(long campusUID)
	{
		return Contexto.GetContextInstance().ViewUnidade.Where((ViewUnidade c) => (long)c.campusUID == campusUID).ToList();
	}

	public ViewUnidade GetUnidadePorId(long unidadeUID)
	{
		return Contexto.GetContextInstance().ViewUnidade.Where((ViewUnidade c) => c.unidadeUID == unidadeUID).FirstOrDefault();
	}
}

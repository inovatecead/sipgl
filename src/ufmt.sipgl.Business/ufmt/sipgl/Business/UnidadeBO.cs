using System.Collections.Generic;
using ufmt.sig.business;
using ufmt.sig.entity;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class UnidadeBO
{
	public IList<ufmt.sig.entity.Campus> GetCampi()
	{
		using ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>();
		return localizacaoBO.GetCampi();
	}

	public IList<Unidade> getUnidadesbyCampus(string unidade, int campus)
	{
		using ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>();
		IList<Unidade> list = null;
		if (string.IsNullOrEmpty(unidade))
		{
			return localizacaoBO.GetUnidades(campus, null, null, null, null, null, null);
		}
		return localizacaoBO.GetUnidades(campus, null, unidade, null, null, null, null);
	}

	public ufmt.sig.entity.Campus GetCampus(string campus)
	{
		using ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>();
		foreach (ufmt.sig.entity.Campus item in localizacaoBO.GetCampi())
		{
			if (item.Nome.ToLower().Contains(campus.ToLower()))
			{
				return item;
			}
		}
		return null;
	}

	public ufmt.sig.entity.Campus GetCampus(int campusUID)
	{
		using ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>();
		foreach (ufmt.sig.entity.Campus item in localizacaoBO.GetCampi())
		{
			if (item.CampusUID == campusUID)
			{
				return item;
			}
		}
		return null;
	}

	public ViewUnidade GetUnidadePorId(long unidadeUID)
	{
		return new UnidadeDAL().GetUnidadePorId(unidadeUID);
	}
}

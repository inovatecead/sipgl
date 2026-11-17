using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class TipoOfertaDisciplinar
{
	private TipoOfertaDisciplinarEnum tipoOferta;

	private string descricao;

	private static List<TipoOfertaDisciplinar> tiposOfertaDisciplinar;

	public TipoOfertaDisciplinarEnum TipoOferta => tipoOferta;

	public virtual int TipoOfertaDisciplinaUID => (int)tipoOferta;

	public virtual string Descricao => descricao;

	static TipoOfertaDisciplinar()
	{
		tiposOfertaDisciplinar = new List<TipoOfertaDisciplinar>();
		tiposOfertaDisciplinar.Add(new TipoOfertaDisciplinar(TipoOfertaDisciplinarEnum.OBRIGATORIA, "OBRIGATÓRIA"));
		tiposOfertaDisciplinar.Add(new TipoOfertaDisciplinar(TipoOfertaDisciplinarEnum.OPTATIVA, "OPTATIVA"));
		tiposOfertaDisciplinar.Add(new TipoOfertaDisciplinar(TipoOfertaDisciplinarEnum.ELETIVA, "ELETIVA"));
	}

	protected TipoOfertaDisciplinar(TipoOfertaDisciplinarEnum tipoOferta, string descricao)
	{
		this.tipoOferta = tipoOferta;
		this.descricao = descricao;
	}

	public static TipoOfertaDisciplinar GetInstance(int tipoOfertaDisciplinarUID)
	{
		try
		{
			return tiposOfertaDisciplinar.Where((TipoOfertaDisciplinar tod) => tod.TipoOfertaDisciplinaUID == tipoOfertaDisciplinarUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static TipoOfertaDisciplinar GetInstance(TipoOfertaDisciplinarEnum tipoOferta)
	{
		return GetInstance((int)tipoOferta);
	}

	public static IList<TipoOfertaDisciplinar> GetInstances()
	{
		return tiposOfertaDisciplinar.OrderBy((TipoOfertaDisciplinar tod) => tod.descricao).ToList();
	}
}

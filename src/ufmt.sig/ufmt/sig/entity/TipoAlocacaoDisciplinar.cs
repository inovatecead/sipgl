using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class TipoAlocacaoDisciplinar
{
	private TipoAlocacaoDisciplinarEnum tipoAlocacao;

	private string descricao;

	private bool requerOrientacao;

	private static List<TipoAlocacaoDisciplinar> tiposAlocacaoDisciplinar;

	public TipoAlocacaoDisciplinarEnum TipoAlocacao => tipoAlocacao;

	public int TipoAlocacaoDisciplinarUID => (int)tipoAlocacao;

	public string Descricao => descricao;

	public bool RequerOrientacao
	{
		get
		{
			return requerOrientacao;
		}
		set
		{
			requerOrientacao = value;
		}
	}

	static TipoAlocacaoDisciplinar()
	{
		tiposAlocacaoDisciplinar = new List<TipoAlocacaoDisciplinar>();
		tiposAlocacaoDisciplinar.Add(new TipoAlocacaoDisciplinar(TipoAlocacaoDisciplinarEnum.AULA, "AULA", requerOrientacao: false));
		tiposAlocacaoDisciplinar.Add(new TipoAlocacaoDisciplinar(TipoAlocacaoDisciplinarEnum.AULA_TEORICA, "AULA TEÓRICA", requerOrientacao: false));
		tiposAlocacaoDisciplinar.Add(new TipoAlocacaoDisciplinar(TipoAlocacaoDisciplinarEnum.AULA_PRATICA, "AULA PRÁTICA", requerOrientacao: false));
		tiposAlocacaoDisciplinar.Add(new TipoAlocacaoDisciplinar(TipoAlocacaoDisciplinarEnum.ORIENTACAO, "ORIENTAÇÃO", requerOrientacao: true));
	}

	protected TipoAlocacaoDisciplinar(TipoAlocacaoDisciplinarEnum tipoAlocacao, string descricao, bool requerOrientacao)
	{
		this.tipoAlocacao = tipoAlocacao;
		this.descricao = descricao;
		this.requerOrientacao = requerOrientacao;
	}

	public static TipoAlocacaoDisciplinar GetInstance(int tipoAlocacaoDisciplinarUID)
	{
		try
		{
			return tiposAlocacaoDisciplinar.Where((TipoAlocacaoDisciplinar tad) => tad.TipoAlocacaoDisciplinarUID == tipoAlocacaoDisciplinarUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static TipoAlocacaoDisciplinar GetInstance(TipoAlocacaoDisciplinarEnum tipoAlocacao)
	{
		return GetInstance((int)tipoAlocacao);
	}

	public static IList<TipoAlocacaoDisciplinar> GetInstances()
	{
		return tiposAlocacaoDisciplinar.OrderBy((TipoAlocacaoDisciplinar tad) => tad.descricao).ToList();
	}
}

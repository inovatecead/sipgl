using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class TipoFracionamentoDisciplinar
{
	private TipoFracionamentoDisciplinarEnum tipoFracionamento;

	private string descricao;

	private static List<TipoFracionamentoDisciplinar> tiposFracionamentoDisciplinar;

	public TipoFracionamentoDisciplinarEnum TipoFracionamento => tipoFracionamento;

	public int TipoFracionamentoDisciplinarUID => (int)tipoFracionamento;

	public string Descricao => descricao;

	static TipoFracionamentoDisciplinar()
	{
		tiposFracionamentoDisciplinar = new List<TipoFracionamentoDisciplinar>();
		tiposFracionamentoDisciplinar.Add(new TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum.NENHUM, "CARGA HORÁRIA TOTAL"));
		tiposFracionamentoDisciplinar.Add(new TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_CARGA_HORARIA, "CARGA HORÁRIA FRACIONADA"));
		tiposFracionamentoDisciplinar.Add(new TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum.ENCARGO_ORIENTACAO, "ENCARGO DE ORIENTAÇÃO"));
		tiposFracionamentoDisciplinar.Add(new TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum.CRIACAO_SUB_TURMA, "SUB-TURMA"));
		tiposFracionamentoDisciplinar.Add(new TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum.DISCIPLINA_CO_MINISTRADA, "DISCIPLINA CO-MINISTRADA"));
		tiposFracionamentoDisciplinar.Add(new TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_MODIFICADO, "FRACIONAMENTO MODIFICADO"));
	}

	protected TipoFracionamentoDisciplinar(TipoFracionamentoDisciplinarEnum tipoFracionamento, string descricao)
	{
		this.tipoFracionamento = tipoFracionamento;
		this.descricao = descricao;
	}

	public static TipoFracionamentoDisciplinar GetInstance(int tipoFracionamentoDisciplinarUID)
	{
		try
		{
			return tiposFracionamentoDisciplinar.Where((TipoFracionamentoDisciplinar tfd) => tfd.TipoFracionamentoDisciplinarUID == tipoFracionamentoDisciplinarUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static TipoFracionamentoDisciplinar GetInstance(TipoFracionamentoDisciplinarEnum tipoFracionamento)
	{
		return GetInstance((int)tipoFracionamento);
	}

	public static IList<TipoFracionamentoDisciplinar> GetInstances()
	{
		return tiposFracionamentoDisciplinar.OrderBy((TipoFracionamentoDisciplinar tfd) => tfd.descricao).ToList();
	}
}

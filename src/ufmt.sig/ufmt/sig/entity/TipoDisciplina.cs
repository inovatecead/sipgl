using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class TipoDisciplina
{
	private TipoDisciplinaEnum tipo;

	private string descricao;

	private bool requerOrientacao;

	private static List<TipoDisciplina> tiposDisciplina;

	public TipoDisciplinaEnum Tipo => tipo;

	public int TipoDisciplinaUID => (int)tipo;

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

	static TipoDisciplina()
	{
		tiposDisciplina = new List<TipoDisciplina>();
		tiposDisciplina.Add(new TipoDisciplina(TipoDisciplinaEnum.REGULAR, "DISCIPLINA REGULAR", requerOrientacao: false));
		tiposDisciplina.Add(new TipoDisciplina(TipoDisciplinaEnum.ESTAGIO, "ESTÁGIO SUPERVISIONADO", requerOrientacao: true));
		tiposDisciplina.Add(new TipoDisciplina(TipoDisciplinaEnum.TCC, "TRABALHO DE CONCLUSÃO DE CURSO", requerOrientacao: true));
		tiposDisciplina.Add(new TipoDisciplina(TipoDisciplinaEnum.MONOGRAFIA, "MONOGRAFIA", requerOrientacao: true));
		tiposDisciplina.Add(new TipoDisciplina(TipoDisciplinaEnum.DISSERTACAO, "DISSERTAÇÃO", requerOrientacao: true));
		tiposDisciplina.Add(new TipoDisciplina(TipoDisciplinaEnum.TESE, "TESE", requerOrientacao: true));
	}

	protected TipoDisciplina(TipoDisciplinaEnum tipo, string descricao, bool requerOrientacao)
	{
		this.tipo = tipo;
		this.descricao = descricao;
		this.requerOrientacao = requerOrientacao;
	}

	public static TipoDisciplina GetInstance(int tipoDisciplinaUID)
	{
		try
		{
			return tiposDisciplina.Where((TipoDisciplina td) => td.TipoDisciplinaUID == tipoDisciplinaUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static TipoDisciplina GetInstance(TipoDisciplinaEnum tipo)
	{
		return GetInstance((int)tipo);
	}

	public static IList<TipoDisciplina> GetInstances()
	{
		return tiposDisciplina.OrderBy((TipoDisciplina td) => td.descricao).ToList();
	}
}

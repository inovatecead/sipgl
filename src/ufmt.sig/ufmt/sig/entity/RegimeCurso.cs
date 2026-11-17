using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class RegimeCurso
{
	private RegimeCursoEnum regime;

	private string descricao;

	private static List<RegimeCurso> regimesCurso;

	public RegimeCursoEnum Regime => regime;

	public virtual int RegimeCursoUID => (int)regime;

	public virtual string Descricao => descricao;

	static RegimeCurso()
	{
		regimesCurso = new List<RegimeCurso>();
		regimesCurso.Add(new RegimeCurso(RegimeCursoEnum.CREDITO, "CRÉDITO"));
		regimesCurso.Add(new RegimeCurso(RegimeCursoEnum.SERIADO, "SERIADO"));
		regimesCurso.Add(new RegimeCurso(RegimeCursoEnum.MODULAR, "MODULAR"));
	}

	protected RegimeCurso(RegimeCursoEnum regime, string descricao)
	{
		this.regime = regime;
		this.descricao = descricao;
	}

	public static RegimeCurso GetInstance(int regimeCursoUID)
	{
		try
		{
			return regimesCurso.Where((RegimeCurso rc) => rc.RegimeCursoUID == regimeCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static RegimeCurso GetInstance(RegimeCursoEnum regime)
	{
		return GetInstance((int)regime);
	}

	public static IList<RegimeCurso> GetInstances()
	{
		return regimesCurso.OrderBy((RegimeCurso rc) => rc.descricao).ToList();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class PeriodicidadeCurso
{
	private PeriodicidadeCursoEnum periodicidade;

	private string descricao;

	private static List<PeriodicidadeCurso> periodicidadesCurso;

	public PeriodicidadeCursoEnum Periodicidade => periodicidade;

	public int PeriodicidadeCursoUID => (int)periodicidade;

	public string Descricao => descricao;

	static PeriodicidadeCurso()
	{
		periodicidadesCurso = new List<PeriodicidadeCurso>();
		periodicidadesCurso.Add(new PeriodicidadeCurso(PeriodicidadeCursoEnum.ANUAL, "ANUAL"));
		periodicidadesCurso.Add(new PeriodicidadeCurso(PeriodicidadeCursoEnum.SEMESTRAL, "SEMESTRAL"));
	}

	protected PeriodicidadeCurso(PeriodicidadeCursoEnum periodicidade, string descricao)
	{
		this.periodicidade = periodicidade;
		this.descricao = descricao;
	}

	public static PeriodicidadeCurso GetInstance(int periodicidadeCursoUID)
	{
		try
		{
			return periodicidadesCurso.Where((PeriodicidadeCurso pc) => pc.PeriodicidadeCursoUID == periodicidadeCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static PeriodicidadeCurso GetInstance(PeriodicidadeCursoEnum periodicidade)
	{
		return GetInstance((int)periodicidade);
	}

	public static IList<PeriodicidadeCurso> GetInstances()
	{
		return periodicidadesCurso.OrderBy((PeriodicidadeCurso pc) => pc.descricao).ToList();
	}
}

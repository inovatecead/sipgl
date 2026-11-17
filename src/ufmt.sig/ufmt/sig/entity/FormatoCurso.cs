using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class FormatoCurso
{
	private FormatoCursoEnum formato;

	private string descricao;

	private static List<FormatoCurso> formatosCurso;

	public FormatoCursoEnum Formato => formato;

	public int FormatoCursoUID => (int)formato;

	public string Descricao => descricao;

	static FormatoCurso()
	{
		formatosCurso = new List<FormatoCurso>();
		formatosCurso.Add(new FormatoCurso(FormatoCursoEnum.PRESENCIAL, "PRESENCIAL"));
		formatosCurso.Add(new FormatoCurso(FormatoCursoEnum.A_DISTANCIA, "À DISTÂNCIA"));
	}

	protected FormatoCurso(FormatoCursoEnum formato, string descricao)
	{
		this.formato = formato;
		this.descricao = descricao;
	}

	public static FormatoCurso GetInstance(int formatoCursoUID)
	{
		try
		{
			return formatosCurso.Where((FormatoCurso fc) => fc.FormatoCursoUID == formatoCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static FormatoCurso GetInstance(FormatoCursoEnum formato)
	{
		return GetInstance((int)formato);
	}

	public static IList<FormatoCurso> GetInstances()
	{
		return formatosCurso.OrderBy((FormatoCurso fc) => fc.descricao).ToList();
	}
}

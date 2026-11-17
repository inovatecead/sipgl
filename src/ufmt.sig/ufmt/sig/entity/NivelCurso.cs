using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class NivelCurso
{
	private NivelCursoEnum nivel;

	private string descricao;

	private static List<NivelCurso> niveisCurso;

	public NivelCursoEnum Nivel => nivel;

	public int NivelCursoUID => (int)nivel;

	public virtual string Descricao => descricao;

	static NivelCurso()
	{
		niveisCurso = new List<NivelCurso>();
		niveisCurso.Add(new NivelCurso(NivelCursoEnum.GRADUACAO, NivelCursoEnum.GRADUACAO.Descricao()));
		niveisCurso.Add(new NivelCurso(NivelCursoEnum.POS_GRADUACAO, NivelCursoEnum.POS_GRADUACAO.Descricao()));
	}

	protected NivelCurso(NivelCursoEnum nivel, string descricao)
	{
		this.nivel = nivel;
		this.descricao = descricao;
	}

	public static NivelCurso GetInstance(int nivelCursoUID)
	{
		try
		{
			return niveisCurso.Where((NivelCurso nc) => nc.NivelCursoUID == nivelCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static NivelCurso GetInstance(NivelCursoEnum nivel)
	{
		return GetInstance((int)nivel);
	}

	public static IList<NivelCurso> GetInstances()
	{
		return niveisCurso.OrderBy((NivelCurso nc) => nc.descricao).ToList();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class TurnoCurso
{
	public enum Enum
	{
		MATUTINO = 1,
		VESPERTINO,
		NOTURNO,
		INTEGRAL,
		VESPERTINO_E_NOTURNO,
		MATUTINO_E_NOTURNO
	}

	private Enum tipo;

	private string descricao;

	private static List<TurnoCurso> turnosCurso;

	public Enum Tipo => tipo;

	public virtual int TurnoCursoUID => (int)tipo;

	public virtual string Descricao => descricao;

	static TurnoCurso()
	{
		turnosCurso = new List<TurnoCurso>();
		turnosCurso.Add(new TurnoCurso(Enum.MATUTINO, "MATUTINO"));
		turnosCurso.Add(new TurnoCurso(Enum.VESPERTINO, "VESPERTINO"));
		turnosCurso.Add(new TurnoCurso(Enum.NOTURNO, "NOTURNO"));
		turnosCurso.Add(new TurnoCurso(Enum.INTEGRAL, "INTEGRAL"));
		turnosCurso.Add(new TurnoCurso(Enum.VESPERTINO_E_NOTURNO, "VESPERTINO E NOTURNO"));
		turnosCurso.Add(new TurnoCurso(Enum.MATUTINO_E_NOTURNO, "MATUTINO E NOTURNO"));
	}

	protected TurnoCurso(Enum tipo, string descricao)
	{
		this.tipo = tipo;
		this.descricao = descricao;
	}

	public static TurnoCurso GetInstance(int turnoCursoUID)
	{
		try
		{
			return turnosCurso.Where((TurnoCurso tc) => tc.TurnoCursoUID == turnoCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static TurnoCurso GetInstance(Enum tipo)
	{
		return GetInstance((int)tipo);
	}

	public static IList<TurnoCurso> GetInstances()
	{
		return turnosCurso.OrderBy((TurnoCurso tc) => tc.descricao).ToList();
	}
}

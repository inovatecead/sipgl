using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class TipoCurso
{
	private TipoCursoEnum tipo;

	private string descricao;

	private static List<TipoCurso> tiposCurso;

	public TipoCursoEnum Tipo => tipo;

	public int TipoCursoUID => (int)tipo;

	public string Descricao => descricao;

	static TipoCurso()
	{
		tiposCurso = new List<TipoCurso>();
		tiposCurso.Add(new TipoCurso(TipoCursoEnum.CURSO, "CURSO"));
		tiposCurso.Add(new TipoCurso(TipoCursoEnum.HABILITACAO, "HABILITAÇÃO"));
		tiposCurso.Add(new TipoCurso(TipoCursoEnum.PROGRAMA_DE_POS_GRADUACAO, "PROGRAMA DE PÓS-GRADUAÇÃO"));
	}

	protected TipoCurso(TipoCursoEnum tipo, string descricao)
	{
		this.tipo = tipo;
		this.descricao = descricao;
	}

	public static TipoCurso GetInstance(int tipoCursoUID)
	{
		try
		{
			return tiposCurso.Where((TipoCurso tc) => tc.TipoCursoUID == tipoCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static TipoCurso GetInstance(TipoCursoEnum tipo)
	{
		return GetInstance((int)tipo);
	}

	public static IList<TipoCurso> GetInstances()
	{
		return tiposCurso.OrderBy((TipoCurso tc) => tc.descricao).ToList();
	}
}

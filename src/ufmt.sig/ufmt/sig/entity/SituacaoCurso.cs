using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class SituacaoCurso
{
	private SituacaoCursoEnum situacao;

	private string descricao;

	private static List<SituacaoCurso> situacoesCurso;

	public SituacaoCursoEnum Situacao => situacao;

	public virtual int SituacaoCursoUID => (int)situacao;

	public virtual string Descricao => descricao;

	static SituacaoCurso()
	{
		situacoesCurso = new List<SituacaoCurso>();
		situacoesCurso.Add(new SituacaoCurso(SituacaoCursoEnum.ATIVO, "ATIVO"));
		situacoesCurso.Add(new SituacaoCurso(SituacaoCursoEnum.INATIVO, "INATIVO"));
	}

	protected SituacaoCurso(SituacaoCursoEnum situacao, string descricao)
	{
		this.situacao = situacao;
		this.descricao = descricao;
	}

	public static SituacaoCurso GetInstance(int situacaoCursoUID)
	{
		try
		{
			return situacoesCurso.Where((SituacaoCurso sc) => sc.SituacaoCursoUID == situacaoCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static SituacaoCurso GetInstance(SituacaoCursoEnum situacao)
	{
		return GetInstance((int)situacao);
	}

	public static IList<SituacaoCurso> GetInstances()
	{
		return situacoesCurso.OrderBy((SituacaoCurso sc) => sc.descricao).ToList();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class ModalidadeCurso
{
	private ModalidadeCursoEnum modalidade;

	private string descricao;

	private NivelCurso nivelCurso;

	private static List<ModalidadeCurso> modalidadesCurso;

	public ModalidadeCursoEnum Modalidade => modalidade;

	public int ModalidadeCursoUID => (int)modalidade;

	public string Descricao => descricao;

	public NivelCurso NivelCurso => nivelCurso;

	static ModalidadeCurso()
	{
		modalidadesCurso = new List<ModalidadeCurso>();
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.LICENCIATURA_PLENA, NivelCurso.GetInstance(NivelCursoEnum.GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.BACHARELADO, NivelCurso.GetInstance(NivelCursoEnum.GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso((ModalidadeCursoEnum)3, NivelCurso.GetInstance(NivelCursoEnum.GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.ESPECIFICO_REFERENTE_PROFISSAO, NivelCurso.GetInstance(NivelCursoEnum.GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.ESPECIALIZACAO, NivelCurso.GetInstance(NivelCursoEnum.POS_GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.MESTRADO, NivelCurso.GetInstance(NivelCursoEnum.POS_GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.DOUTORADO, NivelCurso.GetInstance(NivelCursoEnum.POS_GRADUACAO)));
		modalidadesCurso.Add(new ModalidadeCurso(ModalidadeCursoEnum.MESTRADO_PROFISSIONAL, NivelCurso.GetInstance(NivelCursoEnum.POS_GRADUACAO)));
	}

	protected ModalidadeCurso(ModalidadeCursoEnum modalidade, NivelCurso nivelCurso)
	{
		this.modalidade = modalidade;
		descricao = modalidade.Descricao();
		this.nivelCurso = nivelCurso;
	}

	public static ModalidadeCurso GetInstance(int modalidadeCursoUID)
	{
		try
		{
			return modalidadesCurso.Where((ModalidadeCurso mc) => mc.ModalidadeCursoUID == modalidadeCursoUID).Single();
		}
		catch
		{
			return null;
		}
	}

	public static ModalidadeCurso GetInstance(ModalidadeCursoEnum modalidade)
	{
		return GetInstance((int)modalidade);
	}

	public static IList<ModalidadeCurso> GetInstances()
	{
		return (from mc in modalidadesCurso
			orderby mc.NivelCurso.Descricao, mc.descricao
			select mc).ToList();
	}

	public static IList<ModalidadeCurso> GetInstances(NivelCurso nivelCurso)
	{
		return (from mc in modalidadesCurso
			where mc.NivelCurso.Nivel.Equals(nivelCurso.Nivel)
			orderby mc.Descricao
			select mc).ToList();
	}
}

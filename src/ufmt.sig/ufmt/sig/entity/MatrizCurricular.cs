using System;

namespace ufmt.sig.entity;

[Serializable]
public class MatrizCurricular
{
	private long matrizCurricularUID;

	private Curso curso;

	private int? periodoInicialFuncionamento;

	private int? periodoFinalFuncionamento;

	private SituacaoCurso situacaoCurso;

	private TurnoCurso turnoCurso;

	private RegimeCurso regimeCurso;

	private PeriodicidadeCurso periodicidadeCurso;

	private ModalidadeCurso modalidadeCurso;

	private FormatoCurso formatoCurso;

	private string descricao;

	private int? numeroDeSemanas;

	public virtual long MatrizCurricularUID
	{
		get
		{
			return matrizCurricularUID;
		}
		set
		{
			matrizCurricularUID = value;
		}
	}

	public virtual Curso Curso
	{
		get
		{
			return curso;
		}
		set
		{
			curso = value;
		}
	}

	public virtual int? PeriodoInicialFuncionamento
	{
		get
		{
			return periodoInicialFuncionamento;
		}
		set
		{
			periodoInicialFuncionamento = value;
		}
	}

	public virtual int? PeriodoFinalFuncionamento
	{
		get
		{
			return periodoFinalFuncionamento;
		}
		set
		{
			periodoFinalFuncionamento = value;
		}
	}

	public virtual SituacaoCurso SituacaoCurso
	{
		get
		{
			return situacaoCurso;
		}
		set
		{
			situacaoCurso = value;
		}
	}

	protected internal virtual int SituacaoCursoUID
	{
		get
		{
			return situacaoCurso.SituacaoCursoUID;
		}
		set
		{
			situacaoCurso = SituacaoCurso.GetInstance(value);
		}
	}

	public virtual TurnoCurso TurnoCurso
	{
		get
		{
			return turnoCurso;
		}
		set
		{
			turnoCurso = value;
		}
	}

	protected internal virtual int TurnoCursoUID
	{
		get
		{
			return turnoCurso.TurnoCursoUID;
		}
		set
		{
			turnoCurso = TurnoCurso.GetInstance(value);
		}
	}

	public virtual RegimeCurso RegimeCurso
	{
		get
		{
			return regimeCurso;
		}
		set
		{
			regimeCurso = value;
		}
	}

	protected internal virtual int? RegimeCursoUID
	{
		get
		{
			if (regimeCurso == null)
			{
				return null;
			}
			return regimeCurso.RegimeCursoUID;
		}
		set
		{
			regimeCurso = (value.HasValue ? RegimeCurso.GetInstance(value.Value) : null);
		}
	}

	public virtual PeriodicidadeCurso PeriodicidadeCurso
	{
		get
		{
			return periodicidadeCurso;
		}
		set
		{
			periodicidadeCurso = value;
		}
	}

	protected internal virtual int PeriodicidadeCursoUID
	{
		get
		{
			return periodicidadeCurso.PeriodicidadeCursoUID;
		}
		set
		{
			periodicidadeCurso = PeriodicidadeCurso.GetInstance(value);
		}
	}

	public virtual ModalidadeCurso ModalidadeCurso
	{
		get
		{
			return modalidadeCurso;
		}
		set
		{
			modalidadeCurso = value;
		}
	}

	protected internal virtual int ModalidadeCursoUID
	{
		get
		{
			return modalidadeCurso.ModalidadeCursoUID;
		}
		set
		{
			modalidadeCurso = ModalidadeCurso.GetInstance(value);
		}
	}

	public virtual FormatoCurso FormatoCurso
	{
		get
		{
			return formatoCurso;
		}
		set
		{
			formatoCurso = value;
		}
	}

	protected internal virtual int FormatoCursoUID
	{
		get
		{
			return formatoCurso.FormatoCursoUID;
		}
		set
		{
			formatoCurso = FormatoCurso.GetInstance(value);
		}
	}

	public virtual string Descricao
	{
		get
		{
			return descricao;
		}
		set
		{
			descricao = value;
		}
	}

	public virtual int? NumeroDeSemanas
	{
		get
		{
			return numeroDeSemanas;
		}
		set
		{
			numeroDeSemanas = value;
		}
	}
}

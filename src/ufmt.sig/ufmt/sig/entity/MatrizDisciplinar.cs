using System;

namespace ufmt.sig.entity;

[Serializable]
public class MatrizDisciplinar
{
	private long matrizDisciplinarUID;

	private MatrizCurricular matrizCurricular;

	private int? periodoInicialFuncionamento;

	private int? periodoFinalFuncionamento;

	private int periodoRegularAlocacao;

	private int periodoRegularCurso;

	private TipoOfertaDisciplinar tipoOfertaDisciplinar;

	private long? codigoExterno;

	private string nome;

	private float cargaHorariaTeorica;

	private float cargaHorariaPratica;

	private float cargaHorariaPraticaComponente;

	private string ementa;

	private TipoDisciplina tipoDisciplina;

	private Unidade unidadeOfertante;

	public virtual long MatrizDisciplinarUID
	{
		get
		{
			return matrizDisciplinarUID;
		}
		set
		{
			matrizDisciplinarUID = value;
		}
	}

	public virtual MatrizCurricular MatrizCurricular
	{
		get
		{
			return matrizCurricular;
		}
		set
		{
			matrizCurricular = value;
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

	public virtual int PeriodoRegularAlocacao
	{
		get
		{
			return periodoRegularAlocacao;
		}
		set
		{
			periodoRegularAlocacao = value;
		}
	}

	public virtual int PeriodoRegularCurso
	{
		get
		{
			return periodoRegularCurso;
		}
		set
		{
			periodoRegularCurso = value;
		}
	}

	public virtual TipoOfertaDisciplinar TipoOfertaDisciplinar
	{
		get
		{
			return tipoOfertaDisciplinar;
		}
		set
		{
			tipoOfertaDisciplinar = value;
		}
	}

	protected internal virtual int? TipoOfertaDisciplinarUID
	{
		get
		{
			if (tipoOfertaDisciplinar == null)
			{
				return null;
			}
			return tipoOfertaDisciplinar.TipoOfertaDisciplinaUID;
		}
		set
		{
			tipoOfertaDisciplinar = (value.HasValue ? TipoOfertaDisciplinar.GetInstance(value.Value) : null);
		}
	}

	public virtual long? CodigoExterno
	{
		get
		{
			return codigoExterno;
		}
		set
		{
			codigoExterno = value;
		}
	}

	public virtual string Nome
	{
		get
		{
			return nome;
		}
		set
		{
			nome = value;
		}
	}

	public virtual float CargaHorariaTeorica
	{
		get
		{
			return cargaHorariaTeorica;
		}
		set
		{
			cargaHorariaTeorica = value;
		}
	}

	public virtual float CargaHorariaPratica
	{
		get
		{
			return cargaHorariaPratica;
		}
		set
		{
			cargaHorariaPratica = value;
		}
	}

	public virtual float CargaHorariaPraticaComponente
	{
		get
		{
			return cargaHorariaPraticaComponente;
		}
		set
		{
			cargaHorariaPraticaComponente = value;
		}
	}

	public virtual float CargaHorariaTotal => cargaHorariaTeorica + cargaHorariaPratica + cargaHorariaPraticaComponente;

	public virtual string Ementa
	{
		get
		{
			return ementa;
		}
		set
		{
			ementa = value;
		}
	}

	public virtual TipoDisciplina TipoDisciplina
	{
		get
		{
			return tipoDisciplina;
		}
		set
		{
			tipoDisciplina = value;
		}
	}

	protected internal virtual int TipoDisciplinaUID
	{
		get
		{
			return tipoDisciplina.TipoDisciplinaUID;
		}
		set
		{
			tipoDisciplina = TipoDisciplina.GetInstance(value);
		}
	}

	public virtual Unidade UnidadeOfertante
	{
		get
		{
			return unidadeOfertante;
		}
		set
		{
			unidadeOfertante = value;
		}
	}
}

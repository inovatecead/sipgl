using System;

namespace ufmt.sig.entity;

[Serializable]
public class Curso
{
	private long cursoUID;

	private long? codigoExterno;

	private string nome;

	private DateTime? dataFundacao;

	private string codigoIntegracao;

	private char tipoIntegracao;

	private NivelCurso nivelCurso;

	private TipoCurso tipoCurso;

	private Curso cursoAssociado;

	private InstituicaoConvenio instituicaoConvenio;

	private Campus campus;

	private Unidade unidadeOfertante;

	public virtual long CursoUID
	{
		get
		{
			return cursoUID;
		}
		set
		{
			cursoUID = value;
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

	public virtual DateTime? DataFundacao
	{
		get
		{
			return dataFundacao;
		}
		set
		{
			dataFundacao = value;
		}
	}

	public virtual string CodigoIntegracao
	{
		get
		{
			return codigoIntegracao;
		}
		set
		{
			codigoIntegracao = value;
		}
	}

	public virtual char TipoIntegracao
	{
		get
		{
			return tipoIntegracao;
		}
		set
		{
			tipoIntegracao = value;
		}
	}

	public virtual NivelCurso NivelCurso
	{
		get
		{
			return nivelCurso;
		}
		set
		{
			nivelCurso = value;
		}
	}

	protected internal virtual int NivelCursoUID
	{
		get
		{
			return nivelCurso.NivelCursoUID;
		}
		set
		{
			nivelCurso = NivelCurso.GetInstance(value);
		}
	}

	public virtual TipoCurso TipoCurso
	{
		get
		{
			return tipoCurso;
		}
		set
		{
			tipoCurso = value;
		}
	}

	protected internal virtual int TipoCursoUID
	{
		get
		{
			return tipoCurso.TipoCursoUID;
		}
		set
		{
			tipoCurso = TipoCurso.GetInstance(value);
		}
	}

	public virtual Curso CursoAssociado
	{
		get
		{
			return cursoAssociado;
		}
		set
		{
			cursoAssociado = value;
		}
	}

	public virtual InstituicaoConvenio InstituicaoConvenio
	{
		get
		{
			return instituicaoConvenio;
		}
		set
		{
			instituicaoConvenio = value;
		}
	}

	[Obsolete("Este campo deverá ser removido assim que as matrizes curriculares forem validadas. Deverá ser utilizado o campus da unidade ofertante.")]
	public virtual Campus Campus
	{
		get
		{
			return campus;
		}
		set
		{
			campus = value;
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

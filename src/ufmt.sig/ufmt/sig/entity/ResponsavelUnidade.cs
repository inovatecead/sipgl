using System;

namespace ufmt.sig.entity;

[Serializable]
public class ResponsavelUnidade
{
	private long responsavelUnidadeUID;

	private Pessoa pessoa;

	private Unidade unidade;

	private DateTime dataInicial;

	private DateTime? dataFinal;

	public virtual long ResponsavelUnidadeUID
	{
		get
		{
			return responsavelUnidadeUID;
		}
		set
		{
			responsavelUnidadeUID = value;
		}
	}

	public virtual Pessoa Pessoa
	{
		get
		{
			return pessoa;
		}
		set
		{
			pessoa = value;
		}
	}

	public virtual Unidade Unidade
	{
		get
		{
			return unidade;
		}
		set
		{
			unidade = value;
		}
	}

	public virtual DateTime DataInicial
	{
		get
		{
			return dataInicial;
		}
		set
		{
			dataInicial = value;
		}
	}

	public virtual DateTime? DataFinal
	{
		get
		{
			return dataFinal;
		}
		set
		{
			dataFinal = value;
		}
	}
}

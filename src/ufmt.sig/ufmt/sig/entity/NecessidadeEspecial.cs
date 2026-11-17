using System;

namespace ufmt.sig.entity;

[Serializable]
public class NecessidadeEspecial
{
	private long necessidadeEspecialUID;

	private Pessoa pessoa;

	private TipoNecessidadeEspecial tipoNecessidadeEspecial;

	public virtual long NecessidadeEspecialUID
	{
		get
		{
			return necessidadeEspecialUID;
		}
		set
		{
			necessidadeEspecialUID = value;
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

	public virtual TipoNecessidadeEspecial TipoNecessidadeEspecial
	{
		get
		{
			return tipoNecessidadeEspecial;
		}
		set
		{
			tipoNecessidadeEspecial = value;
		}
	}
}

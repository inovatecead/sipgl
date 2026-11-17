using System;

namespace ufmt.sig.entity;

[Serializable]
public class InstituicaoConvenio
{
	private int instituicaoConvenioUID;

	private string tipo;

	private string nome;

	private string sigla;

	private string cnpj;

	public virtual int InstituicaoConvenioUID
	{
		get
		{
			return instituicaoConvenioUID;
		}
		set
		{
			instituicaoConvenioUID = value;
		}
	}

	public virtual string Tipo
	{
		get
		{
			return tipo;
		}
		set
		{
			tipo = value;
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

	public virtual string Sigla
	{
		get
		{
			return sigla;
		}
		set
		{
			sigla = value;
		}
	}

	public virtual string Cnpj
	{
		get
		{
			return cnpj;
		}
		set
		{
			cnpj = value;
		}
	}
}

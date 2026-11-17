using System;

namespace ufmt.sig.entity;

[Serializable]
public class Permissao
{
	private long permissaoUID;

	private Aplicacao aplicacao;

	private string nome;

	private string descricao;

	private string urlRelativa;

	public virtual long PermissaoUID
	{
		get
		{
			return permissaoUID;
		}
		set
		{
			permissaoUID = value;
		}
	}

	public virtual Aplicacao Aplicacao
	{
		get
		{
			return aplicacao;
		}
		set
		{
			aplicacao = value;
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

	public virtual string UrlRelativa
	{
		get
		{
			return urlRelativa;
		}
		set
		{
			urlRelativa = value;
		}
	}
}

using System;

namespace ufmt.sig.entity;

[Serializable]
public class ConfirmaEmail
{
	private long confirmaEmailUID;

	private Pessoa pessoa;

	private string novoEmail;

	private string codigoConfirmacao;

	public virtual long ConfirmaEmailUID
	{
		get
		{
			return confirmaEmailUID;
		}
		set
		{
			confirmaEmailUID = value;
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

	public virtual string NovoEmail
	{
		get
		{
			return novoEmail;
		}
		set
		{
			novoEmail = value;
		}
	}

	public virtual string CodigoConfirmacao
	{
		get
		{
			return codigoConfirmacao;
		}
		set
		{
			codigoConfirmacao = value;
		}
	}
}

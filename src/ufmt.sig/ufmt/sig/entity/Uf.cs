using System;

namespace ufmt.sig.entity;

[Serializable]
public class Uf
{
	private string ufUID;

	private string nome;

	private short codigoExterno;

	public virtual string UfUID
	{
		get
		{
			return ufUID;
		}
		set
		{
			ufUID = value;
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

	public virtual short CodigoExterno
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
}

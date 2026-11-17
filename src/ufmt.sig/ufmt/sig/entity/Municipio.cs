using System;

namespace ufmt.sig.entity;

[Serializable]
public class Municipio
{
	private int municipioUID;

	private string nome;

	private Uf uf;

	public virtual int MunicipioUID
	{
		get
		{
			return municipioUID;
		}
		set
		{
			municipioUID = value;
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

	public virtual Uf Uf
	{
		get
		{
			return uf;
		}
		set
		{
			uf = value;
		}
	}
}

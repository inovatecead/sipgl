using System;

namespace ufmt.sig.entity.cineclube;

[Serializable]
public class Genero
{
	private int generoUID;

	private string descricao;

	public virtual int GeneroUID
	{
		get
		{
			return generoUID;
		}
		set
		{
			generoUID = value;
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
}

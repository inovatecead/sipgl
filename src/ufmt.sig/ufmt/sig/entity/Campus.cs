using System;

namespace ufmt.sig.entity;

[Serializable]
public class Campus
{
	private int campusUID;

	private string nome;

	public virtual int CampusUID
	{
		get
		{
			return campusUID;
		}
		set
		{
			campusUID = value;
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
}

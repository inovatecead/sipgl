using System;

namespace ufmt.sig.entity;

[Serializable]
public class Perfil
{
	private long perfilUID;

	private string nome;

	private string descricao;

	public virtual long PerfilUID
	{
		get
		{
			return perfilUID;
		}
		set
		{
			perfilUID = value;
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
}

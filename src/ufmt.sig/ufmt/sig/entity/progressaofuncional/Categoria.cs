using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class Categoria : IEntidade
{
	private int id;

	private string descricao;

	private string nome;

	public virtual int Id
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
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

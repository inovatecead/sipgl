using System;

namespace ufmt.sig.entity;

[Serializable]
public class JornadaTrabalho
{
	private int jornadaTrabalhoUID;

	private int jornadaTrabalhoSiape;

	private string descricao;

	public virtual int JornadaTrabalhoUID
	{
		get
		{
			return jornadaTrabalhoUID;
		}
		set
		{
			jornadaTrabalhoUID = value;
		}
	}

	public virtual int JornadaTrabalhoSiape
	{
		get
		{
			return jornadaTrabalhoSiape;
		}
		set
		{
			jornadaTrabalhoSiape = value;
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

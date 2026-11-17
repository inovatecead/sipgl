using System;

namespace ufmt.sig.entity.cineclube;

[Serializable]
public class Agenda
{
	private int agendaUID;

	private Filme filme;

	private DateTime data;

	public virtual int AgendaUID
	{
		get
		{
			return agendaUID;
		}
		set
		{
			agendaUID = value;
		}
	}

	public virtual Filme Filme
	{
		get
		{
			return filme;
		}
		set
		{
			filme = value;
		}
	}

	public virtual DateTime Data
	{
		get
		{
			return data;
		}
		set
		{
			data = value;
		}
	}
}

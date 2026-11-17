using System;

namespace ufmt.sig.entity.sisvote;

public class Voto
{
	private long votoUID;

	private Cargo cargo;

	private Candidato candidato;

	private Servidor servidor;

	private TipoVoto tipoVoto;

	private string ip;

	private DateTime dataHora;

	public virtual long VotoUID
	{
		get
		{
			return votoUID;
		}
		set
		{
			votoUID = value;
		}
	}

	public virtual Cargo Cargo
	{
		get
		{
			return cargo;
		}
		set
		{
			cargo = value;
		}
	}

	public virtual Candidato Candidato
	{
		get
		{
			return candidato;
		}
		set
		{
			candidato = value;
		}
	}

	public virtual Servidor Servidor
	{
		get
		{
			return servidor;
		}
		set
		{
			servidor = value;
		}
	}

	public virtual TipoVoto TipoVoto
	{
		get
		{
			return tipoVoto;
		}
		set
		{
			tipoVoto = value;
		}
	}

	public virtual string Ip
	{
		get
		{
			return ip;
		}
		set
		{
			ip = value;
		}
	}

	public virtual DateTime DataHora
	{
		get
		{
			return dataHora;
		}
		set
		{
			dataHora = value;
		}
	}
}

using System;

namespace ufmt.sig.entity;

[Serializable]
public class Cargo
{
	private long cargoUID;

	private int cargoSiape;

	private int cargoGrupoSiape;

	private string nome;

	private int tipoSiape;

	public virtual long CargoUID
	{
		get
		{
			return cargoUID;
		}
		set
		{
			cargoUID = value;
		}
	}

	public virtual int CargoSiape
	{
		get
		{
			return cargoSiape;
		}
		set
		{
			cargoSiape = value;
		}
	}

	public virtual int CargoGrupoSiape
	{
		get
		{
			return cargoGrupoSiape;
		}
		set
		{
			cargoGrupoSiape = value;
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

	public virtual int TipoSiape
	{
		get
		{
			return tipoSiape;
		}
		set
		{
			tipoSiape = value;
		}
	}
}

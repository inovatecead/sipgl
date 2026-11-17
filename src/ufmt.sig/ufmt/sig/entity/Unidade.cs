using System;
using System.Xml.Serialization;

namespace ufmt.sig.entity;

[Serializable]
public class Unidade
{
	private long unidadeUID;

	private Unidade unidadeSuperior;

	private Campus campus;

	private string nome;

	private string sigla;

	private string hierarquia;

	[XmlIgnore]
	private TipoUnidadeEnum tipoUnidade;

	public virtual long UnidadeUID
	{
		get
		{
			return unidadeUID;
		}
		set
		{
			unidadeUID = value;
		}
	}

	public virtual Unidade UnidadeSuperior
	{
		get
		{
			return unidadeSuperior;
		}
		set
		{
			unidadeSuperior = value;
		}
	}

	public virtual Campus Campus
	{
		get
		{
			return campus;
		}
		set
		{
			campus = value;
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

	public virtual string Sigla
	{
		get
		{
			return sigla;
		}
		set
		{
			sigla = value;
		}
	}

	public virtual string Hierarquia
	{
		get
		{
			return hierarquia;
		}
		set
		{
			hierarquia = value;
		}
	}

	protected internal virtual int CodigoTipoUnidade
	{
		get
		{
			return (int)tipoUnidade;
		}
		set
		{
			tipoUnidade = (TipoUnidadeEnum)value;
		}
	}

	[XmlIgnore]
	public virtual TipoUnidadeEnum TipoUnidade
	{
		get
		{
			return tipoUnidade;
		}
		set
		{
			tipoUnidade = value;
		}
	}
}

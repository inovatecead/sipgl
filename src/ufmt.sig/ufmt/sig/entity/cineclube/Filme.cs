using System;

namespace ufmt.sig.entity.cineclube;

[Serializable]
public class Filme
{
	private int filmeUID;

	private string titulo;

	private string direcao;

	private string producao;

	private string infoFotografia;

	private string infoMontagem;

	private string sinopse;

	private string elenco;

	private Genero genero;

	public virtual int FilmeUID
	{
		get
		{
			return filmeUID;
		}
		set
		{
			filmeUID = value;
		}
	}

	public virtual string Titulo
	{
		get
		{
			return titulo;
		}
		set
		{
			titulo = value;
		}
	}

	public virtual string Direcao
	{
		get
		{
			return direcao;
		}
		set
		{
			direcao = value;
		}
	}

	public virtual string Producao
	{
		get
		{
			return producao;
		}
		set
		{
			producao = value;
		}
	}

	public virtual string InfoFotografia
	{
		get
		{
			return infoFotografia;
		}
		set
		{
			infoFotografia = value;
		}
	}

	public virtual string InfoMontagem
	{
		get
		{
			return infoMontagem;
		}
		set
		{
			infoMontagem = value;
		}
	}

	public virtual string Sinopse
	{
		get
		{
			return sinopse;
		}
		set
		{
			sinopse = value;
		}
	}

	public virtual string Elenco
	{
		get
		{
			return elenco;
		}
		set
		{
			elenco = value;
		}
	}

	public virtual Genero Genero
	{
		get
		{
			return genero;
		}
		set
		{
			genero = value;
		}
	}
}

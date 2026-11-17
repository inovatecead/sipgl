using System;

namespace ufmt.sig.entity;

[Serializable]
public class HomologacaoPia
{
	private long homologacaoPiaUID;

	private int ano;

	private short periodo;

	private Servidor servidorDocente;

	private Servidor servidorAprovador;

	private Servidor servidorHomologador;

	private bool avaliacaoAprovador;

	private bool avaliacaoHomologador;

	private string justificativaAprovador;

	private string justificativaHomologador;

	private string observacaoDocente;

	public virtual long HomologacaoPiaUID
	{
		get
		{
			return homologacaoPiaUID;
		}
		set
		{
			homologacaoPiaUID = value;
		}
	}

	public virtual int Ano
	{
		get
		{
			return ano;
		}
		set
		{
			ano = value;
		}
	}

	public virtual short Periodo
	{
		get
		{
			return periodo;
		}
		set
		{
			periodo = value;
		}
	}

	public virtual Servidor ServidorDocente
	{
		get
		{
			return servidorDocente;
		}
		set
		{
			servidorDocente = value;
		}
	}

	public virtual Servidor ServidorAprovador
	{
		get
		{
			return servidorAprovador;
		}
		set
		{
			servidorAprovador = value;
		}
	}

	public virtual Servidor ServidorHomologador
	{
		get
		{
			return servidorHomologador;
		}
		set
		{
			servidorHomologador = value;
		}
	}

	public virtual bool AvaliacaoAprovador
	{
		get
		{
			return avaliacaoAprovador;
		}
		set
		{
			avaliacaoAprovador = value;
		}
	}

	public virtual bool AvaliacaoHomologador
	{
		get
		{
			return avaliacaoHomologador;
		}
		set
		{
			avaliacaoHomologador = value;
		}
	}

	public virtual string JustificativaAprovador
	{
		get
		{
			return justificativaAprovador;
		}
		set
		{
			justificativaAprovador = value;
		}
	}

	public virtual string JustificativaHomologador
	{
		get
		{
			return justificativaHomologador;
		}
		set
		{
			justificativaHomologador = value;
		}
	}

	public virtual string ObservacaoDocente
	{
		get
		{
			return observacaoDocente;
		}
		set
		{
			observacaoDocente = value;
		}
	}
}

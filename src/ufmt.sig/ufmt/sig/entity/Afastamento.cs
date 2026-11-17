using System;

namespace ufmt.sig.entity;

[Serializable]
public class Afastamento
{
	private long afastamentoUID;

	private int ano;

	private short periodo;

	private Servidor servidor;

	private DateTime dataInicial;

	private DateTime? dataFinal;

	private string justificativa;

	private string documentoComprobatorio;

	public virtual long AfastamentoUID
	{
		get
		{
			return afastamentoUID;
		}
		set
		{
			afastamentoUID = value;
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

	public virtual DateTime DataInicial
	{
		get
		{
			return dataInicial;
		}
		set
		{
			dataInicial = value;
		}
	}

	public virtual DateTime? DataFinal
	{
		get
		{
			return dataFinal;
		}
		set
		{
			dataFinal = value;
		}
	}

	public virtual string Justificativa
	{
		get
		{
			return justificativa;
		}
		set
		{
			justificativa = value;
		}
	}

	public virtual string DocumentoComprobatorio
	{
		get
		{
			return documentoComprobatorio;
		}
		set
		{
			documentoComprobatorio = value;
		}
	}
}

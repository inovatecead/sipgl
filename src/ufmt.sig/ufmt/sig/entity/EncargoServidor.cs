using System;

namespace ufmt.sig.entity;

[Serializable]
public class EncargoServidor
{
	private long encargoServidorUID;

	private Servidor servidor;

	private int ano;

	private short periodo;

	private TipoEncargoServidor tipoEncargoServidor;

	private string descricao;

	private float cargaHorariaSemanal;

	private string complemento;

	private string complemento2;

	public virtual long EncargoServidorUID
	{
		get
		{
			return encargoServidorUID;
		}
		set
		{
			encargoServidorUID = value;
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

	public virtual TipoEncargoServidor TipoEncargoServidor
	{
		get
		{
			return tipoEncargoServidor;
		}
		set
		{
			tipoEncargoServidor = value;
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

	public virtual string DescricaoAtividade
	{
		get
		{
			if (!tipoEncargoServidor.RequerDetalhamento)
			{
				return tipoEncargoServidor.Descricao;
			}
			return descricao + " (" + tipoEncargoServidor.Descricao + ")";
		}
	}

	public virtual float CargaHorariaSemanal
	{
		get
		{
			return cargaHorariaSemanal;
		}
		set
		{
			cargaHorariaSemanal = value;
		}
	}

	public virtual string Complemento
	{
		get
		{
			return complemento;
		}
		set
		{
			complemento = value;
		}
	}

	public virtual string Complemento2
	{
		get
		{
			return complemento2;
		}
		set
		{
			complemento2 = value;
		}
	}
}

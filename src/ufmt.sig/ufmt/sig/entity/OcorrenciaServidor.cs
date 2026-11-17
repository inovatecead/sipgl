using System;

namespace ufmt.sig.entity;

[Serializable]
public class OcorrenciaServidor
{
	private long ocorrenciaServidorUID;

	private Servidor servidor;

	private TipoOcorrenciaServidor tipoOcorrenciaServidor;

	private DateTime data;

	private int? diplomaLegalCodigo;

	private string diplomaLegalNumero;

	private DateTime? diplomaLegalData;

	private DateTime? afastamentoDataFinal;

	public virtual long OcorrenciaServidorUID
	{
		get
		{
			return ocorrenciaServidorUID;
		}
		set
		{
			ocorrenciaServidorUID = value;
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

	public virtual TipoOcorrenciaServidor TipoOcorrenciaServidor
	{
		get
		{
			return tipoOcorrenciaServidor;
		}
		set
		{
			tipoOcorrenciaServidor = value;
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

	public virtual int? DiplomaLegalCodigo
	{
		get
		{
			return diplomaLegalCodigo;
		}
		set
		{
			diplomaLegalCodigo = value;
		}
	}

	public virtual string DiplomaLegalNumero
	{
		get
		{
			return diplomaLegalNumero;
		}
		set
		{
			diplomaLegalNumero = value;
		}
	}

	public virtual DateTime? DiplomaLegalData
	{
		get
		{
			return diplomaLegalData;
		}
		set
		{
			diplomaLegalData = value;
		}
	}

	public virtual DateTime? AfastamentoDataFinal
	{
		get
		{
			return afastamentoDataFinal;
		}
		set
		{
			afastamentoDataFinal = value;
		}
	}
}

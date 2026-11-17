using System;

namespace ufmt.sig.entity;

[Serializable]
public class TipoOcorrenciaServidor
{
	private int tipoOcorrenciaServidorUID;

	private int ocorrenciaSiape;

	private int ocorrenciaGrupoSiape;

	private int tipoOcorrenciaSiape;

	private string descricao;

	public virtual int TipoOcorrenciaServidorUID
	{
		get
		{
			return tipoOcorrenciaServidorUID;
		}
		set
		{
			tipoOcorrenciaServidorUID = value;
		}
	}

	public virtual int OcorrenciaSiape
	{
		get
		{
			return ocorrenciaSiape;
		}
		set
		{
			ocorrenciaSiape = value;
		}
	}

	public virtual int OcorrenciaGrupoSiape
	{
		get
		{
			return ocorrenciaGrupoSiape;
		}
		set
		{
			ocorrenciaGrupoSiape = value;
		}
	}

	public virtual int TipoOcorrenciaSiape
	{
		get
		{
			return tipoOcorrenciaSiape;
		}
		set
		{
			tipoOcorrenciaSiape = value;
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

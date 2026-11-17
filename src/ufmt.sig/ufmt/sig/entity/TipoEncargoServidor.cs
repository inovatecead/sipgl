using System;

namespace ufmt.sig.entity;

[Serializable]
public class TipoEncargoServidor
{
	private int tipoEncargoServidorUID;

	private string descricao;

	private CategoriaEncargoEnum categoriaEncargo;

	private float? cargaHoraria;

	private bool cargaHorariaFixa;

	private float reducaoCargaHorariaEnsino;

	private bool requerDetalhamento;

	public virtual int TipoEncargoServidorUID
	{
		get
		{
			return tipoEncargoServidorUID;
		}
		set
		{
			tipoEncargoServidorUID = value;
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

	public virtual CategoriaEncargoEnum CategoriaEncargo
	{
		get
		{
			return categoriaEncargo;
		}
		set
		{
			categoriaEncargo = value;
		}
	}

	protected internal virtual int CategoriaEncargoUID
	{
		get
		{
			return (int)categoriaEncargo;
		}
		set
		{
			categoriaEncargo = (CategoriaEncargoEnum)value;
		}
	}

	public virtual float? CargaHoraria
	{
		get
		{
			return cargaHoraria;
		}
		set
		{
			cargaHoraria = value;
		}
	}

	public virtual bool CargaHorariaFixa
	{
		get
		{
			return cargaHorariaFixa;
		}
		set
		{
			cargaHorariaFixa = value;
		}
	}

	public virtual float ReducaoCargaHorariaEnsino
	{
		get
		{
			return reducaoCargaHorariaEnsino;
		}
		set
		{
			reducaoCargaHorariaEnsino = value;
		}
	}

	public virtual bool RequerDetalhamento
	{
		get
		{
			return requerDetalhamento;
		}
		set
		{
			requerDetalhamento = value;
		}
	}
}

using System;

namespace ufmt.sig.entity;

[Serializable]
public class TipoTitulacao
{
	private int tipoTitulacaoUID;

	private string descricao;

	private int? titulacaoSiape;

	public virtual int TipoTitulacaoUID
	{
		get
		{
			return tipoTitulacaoUID;
		}
		set
		{
			tipoTitulacaoUID = value;
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

	public virtual int? TitulacaoSiape
	{
		get
		{
			return titulacaoSiape;
		}
		set
		{
			titulacaoSiape = value;
		}
	}
}

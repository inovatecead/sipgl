using System;

namespace ufmt.sig.entity;

[Serializable]
public class SituacaoServidor
{
	private int situacaoServidorUID;

	private string descricao;

	private int? situacaoSiape;

	public virtual int SituacaoServidorUID
	{
		get
		{
			return situacaoServidorUID;
		}
		set
		{
			situacaoServidorUID = value;
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

	public virtual int? SituacaoSiape
	{
		get
		{
			return situacaoSiape;
		}
		set
		{
			situacaoSiape = value;
		}
	}
}

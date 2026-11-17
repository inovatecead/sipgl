using System;

namespace ufmt.sig.entity.sisvote;

public class Eleicao
{
	private long eleicaoUID;

	private DateTime dataHoraInicio;

	private DateTime dataHoraFim;

	private string descricao;

	private SituacaoEleicaoEnum situacao;

	public virtual long EleicaoUID
	{
		get
		{
			return eleicaoUID;
		}
		set
		{
			eleicaoUID = value;
		}
	}

	public virtual DateTime DataHoraInicio
	{
		get
		{
			return dataHoraInicio;
		}
		set
		{
			dataHoraInicio = value;
		}
	}

	public virtual DateTime DataHoraFim
	{
		get
		{
			return dataHoraFim;
		}
		set
		{
			dataHoraFim = value;
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

	protected internal virtual int CodigoSituacao
	{
		get
		{
			return (int)situacao;
		}
		set
		{
			situacao = (SituacaoEleicaoEnum)value;
		}
	}

	public virtual SituacaoEleicaoEnum Situacao
	{
		get
		{
			return situacao;
		}
		set
		{
			situacao = value;
		}
	}
}

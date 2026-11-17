using System;

namespace ufmt.sig.entity;

[Serializable]
public class Log
{
	public enum OperacaoLog
	{
		ENTROU_NO_SISTEMA = 1,
		CADASTROU_NO_IDBUFMT,
		REINICIOU_SENHA
	}

	private long logUID;

	private Usuario usuario;

	private Aplicacao aplicacao;

	private DateTime dataHora;

	private string operacao;

	private string ip;

	private string valorAntigo;

	private string valorNovo;

	private string detalhes;

	public virtual long LogUID
	{
		get
		{
			return logUID;
		}
		set
		{
			logUID = value;
		}
	}

	public virtual Usuario Usuario
	{
		get
		{
			return usuario;
		}
		set
		{
			usuario = value;
		}
	}

	public virtual Aplicacao Aplicacao
	{
		get
		{
			return aplicacao;
		}
		set
		{
			aplicacao = value;
		}
	}

	public virtual DateTime DataHora
	{
		get
		{
			return dataHora;
		}
		set
		{
			dataHora = value;
		}
	}

	public virtual string Operacao
	{
		get
		{
			return operacao;
		}
		set
		{
			operacao = value;
		}
	}

	public virtual string Ip
	{
		get
		{
			return ip;
		}
		set
		{
			ip = value;
		}
	}

	public virtual string ValorAntigo
	{
		get
		{
			return valorAntigo;
		}
		set
		{
			valorAntigo = value;
		}
	}

	public virtual string ValorNovo
	{
		get
		{
			return valorNovo;
		}
		set
		{
			valorNovo = value;
		}
	}

	public virtual string Detalhes
	{
		get
		{
			return detalhes;
		}
		set
		{
			detalhes = value;
		}
	}
}

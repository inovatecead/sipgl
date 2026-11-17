using System;

namespace ufmt.sig.entity;

[Serializable]
public class Aplicacao
{
	private long aplicacaoUID;

	private string nome;

	private string descricao;

	private byte[] icone;

	private string url;

	private string sigla;

	private string situacao;

	private string plataforma;

	private string sistemaOperacional;

	private string sgbd;

	private string requisitosMinimos;

	private string versao;

	private string objetivo;

	public virtual long AplicacaoUID
	{
		get
		{
			return aplicacaoUID;
		}
		set
		{
			aplicacaoUID = value;
		}
	}

	public virtual string Nome
	{
		get
		{
			return nome;
		}
		set
		{
			nome = value;
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

	public virtual byte[] Icone
	{
		get
		{
			return icone;
		}
		set
		{
			icone = value;
		}
	}

	public virtual string Url
	{
		get
		{
			return url;
		}
		set
		{
			url = value;
		}
	}

	public virtual string Sigla
	{
		get
		{
			return sigla;
		}
		set
		{
			sigla = value;
		}
	}

	public virtual string Situacao
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

	public virtual string Plataforma
	{
		get
		{
			return plataforma;
		}
		set
		{
			plataforma = value;
		}
	}

	public virtual string SistemaOperacional
	{
		get
		{
			return sistemaOperacional;
		}
		set
		{
			sistemaOperacional = value;
		}
	}

	public virtual string Sgbd
	{
		get
		{
			return sgbd;
		}
		set
		{
			sgbd = value;
		}
	}

	public virtual string RequisitosMinimos
	{
		get
		{
			return requisitosMinimos;
		}
		set
		{
			requisitosMinimos = value;
		}
	}

	public virtual string Versao
	{
		get
		{
			return versao;
		}
		set
		{
			versao = value;
		}
	}

	public virtual string Objetivo
	{
		get
		{
			return objetivo;
		}
		set
		{
			objetivo = value;
		}
	}
}

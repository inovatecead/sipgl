using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
public class Aplicacao
{
	private long aplicacaoUIDField;

	private string descricaoField;

	private byte[] iconeField;

	private string nomeField;

	private string objetivoField;

	private string plataformaField;

	private string requisitosMinimosField;

	private string sgbdField;

	private string siglaField;

	private string sistemaOperacionalField;

	private string situacaoField;

	private string urlField;

	private string versaoField;

	public long aplicacaoUID
	{
		get
		{
			return aplicacaoUIDField;
		}
		set
		{
			aplicacaoUIDField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string descricao
	{
		get
		{
			return descricaoField;
		}
		set
		{
			descricaoField = value;
		}
	}

	[XmlElement(DataType = "base64Binary", IsNullable = true)]
	public byte[] icone
	{
		get
		{
			return iconeField;
		}
		set
		{
			iconeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string nome
	{
		get
		{
			return nomeField;
		}
		set
		{
			nomeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string objetivo
	{
		get
		{
			return objetivoField;
		}
		set
		{
			objetivoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string plataforma
	{
		get
		{
			return plataformaField;
		}
		set
		{
			plataformaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string requisitosMinimos
	{
		get
		{
			return requisitosMinimosField;
		}
		set
		{
			requisitosMinimosField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string sgbd
	{
		get
		{
			return sgbdField;
		}
		set
		{
			sgbdField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string sigla
	{
		get
		{
			return siglaField;
		}
		set
		{
			siglaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string sistemaOperacional
	{
		get
		{
			return sistemaOperacionalField;
		}
		set
		{
			sistemaOperacionalField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string situacao
	{
		get
		{
			return situacaoField;
		}
		set
		{
			situacaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string url
	{
		get
		{
			return urlField;
		}
		set
		{
			urlField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string versao
	{
		get
		{
			return versaoField;
		}
		set
		{
			versaoField = value;
		}
	}
}

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
[XmlType(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
public class AplicacaoEntity
{
	private long aplicacaoUIDField;

	private bool aplicacaoUIDFieldSpecified;

	private string chaveField;

	private string descricaoField;

	private string emailAdministradorField;

	private byte[] iconeField;

	private bool integradoField;

	private bool integradoFieldSpecified;

	private string nomeField;

	private string objetivoField;

	private string plataformaField;

	private int qtdeField;

	private bool qtdeFieldSpecified;

	private string requisitosMinimosField;

	private string sgbdField;

	private string siglaField;

	private string siglaNomeField;

	private string sistemaOperacionalField;

	private string situacaoField;

	private string urlField;

	private string versaoField;

	public long AplicacaoUID
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

	[XmlIgnore]
	public bool AplicacaoUIDSpecified
	{
		get
		{
			return aplicacaoUIDFieldSpecified;
		}
		set
		{
			aplicacaoUIDFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Chave
	{
		get
		{
			return chaveField;
		}
		set
		{
			chaveField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Descricao
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

	[XmlElement(IsNullable = true)]
	public string EmailAdministrador
	{
		get
		{
			return emailAdministradorField;
		}
		set
		{
			emailAdministradorField = value;
		}
	}

	[XmlElement(DataType = "base64Binary", IsNullable = true)]
	public byte[] Icone
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

	public bool Integrado
	{
		get
		{
			return integradoField;
		}
		set
		{
			integradoField = value;
		}
	}

	[XmlIgnore]
	public bool IntegradoSpecified
	{
		get
		{
			return integradoFieldSpecified;
		}
		set
		{
			integradoFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Nome
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
	public string Objetivo
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
	public string Plataforma
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

	public int Qtde
	{
		get
		{
			return qtdeField;
		}
		set
		{
			qtdeField = value;
		}
	}

	[XmlIgnore]
	public bool QtdeSpecified
	{
		get
		{
			return qtdeFieldSpecified;
		}
		set
		{
			qtdeFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string RequisitosMinimos
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
	public string Sgbd
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
	public string Sigla
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
	public string SiglaNome
	{
		get
		{
			return siglaNomeField;
		}
		set
		{
			siglaNomeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string SistemaOperacional
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
	public string Situacao
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
	public string Url
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
	public string Versao
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

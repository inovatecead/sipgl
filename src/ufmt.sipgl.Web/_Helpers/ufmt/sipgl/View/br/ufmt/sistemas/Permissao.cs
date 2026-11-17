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
public class Permissao
{
	private Aplicacao aplicacaoField;

	private string descricaoField;

	private string nomeField;

	private long permissaoUIDField;

	private string urlRelativaField;

	[XmlElement(IsNullable = true)]
	public Aplicacao aplicacao
	{
		get
		{
			return aplicacaoField;
		}
		set
		{
			aplicacaoField = value;
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

	public long permissaoUID
	{
		get
		{
			return permissaoUIDField;
		}
		set
		{
			permissaoUIDField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string urlRelativa
	{
		get
		{
			return urlRelativaField;
		}
		set
		{
			urlRelativaField = value;
		}
	}
}

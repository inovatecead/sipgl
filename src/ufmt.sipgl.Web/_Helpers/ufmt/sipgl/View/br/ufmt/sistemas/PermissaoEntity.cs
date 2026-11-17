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
public class PermissaoEntity
{
	private AplicacaoEntity aplicacaoField;

	private string descricaoField;

	private string nomeField;

	private long permissaoUIDField;

	private bool permissaoUIDFieldSpecified;

	private string urlRelativaField;

	[XmlElement(IsNullable = true)]
	public AplicacaoEntity Aplicacao
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

	public long PermissaoUID
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

	[XmlIgnore]
	public bool PermissaoUIDSpecified
	{
		get
		{
			return permissaoUIDFieldSpecified;
		}
		set
		{
			permissaoUIDFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string UrlRelativa
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

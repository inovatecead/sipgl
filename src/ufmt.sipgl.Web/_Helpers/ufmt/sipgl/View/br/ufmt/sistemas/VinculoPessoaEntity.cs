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
public class VinculoPessoaEntity
{
	private string cpfField;

	private string registroField;

	private string siglaField;

	private string vinculoField;

	[XmlElement(IsNullable = true)]
	public string Cpf
	{
		get
		{
			return cpfField;
		}
		set
		{
			cpfField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Registro
	{
		get
		{
			return registroField;
		}
		set
		{
			registroField = value;
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
	public string Vinculo
	{
		get
		{
			return vinculoField;
		}
		set
		{
			vinculoField = value;
		}
	}
}

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
public class Campus
{
	private int campusUIDField;

	private string nomeField;

	public int campusUID
	{
		get
		{
			return campusUIDField;
		}
		set
		{
			campusUIDField = value;
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
}

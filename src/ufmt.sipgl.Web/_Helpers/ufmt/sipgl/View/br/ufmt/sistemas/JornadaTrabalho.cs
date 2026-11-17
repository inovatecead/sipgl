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
public class JornadaTrabalho
{
	private string descricaoField;

	private int jornadaTrabalhoSiapeField;

	private int jornadaTrabalhoUIDField;

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

	public int jornadaTrabalhoSiape
	{
		get
		{
			return jornadaTrabalhoSiapeField;
		}
		set
		{
			jornadaTrabalhoSiapeField = value;
		}
	}

	public int jornadaTrabalhoUID
	{
		get
		{
			return jornadaTrabalhoUIDField;
		}
		set
		{
			jornadaTrabalhoUIDField = value;
		}
	}
}

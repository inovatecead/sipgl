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
public class Cargo
{
	private int cargoGrupoSiapeField;

	private int cargoSiapeField;

	private long cargoUIDField;

	private string nomeField;

	private int tipoSiapeField;

	public int cargoGrupoSiape
	{
		get
		{
			return cargoGrupoSiapeField;
		}
		set
		{
			cargoGrupoSiapeField = value;
		}
	}

	public int cargoSiape
	{
		get
		{
			return cargoSiapeField;
		}
		set
		{
			cargoSiapeField = value;
		}
	}

	public long cargoUID
	{
		get
		{
			return cargoUIDField;
		}
		set
		{
			cargoUIDField = value;
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

	public int tipoSiape
	{
		get
		{
			return tipoSiapeField;
		}
		set
		{
			tipoSiapeField = value;
		}
	}
}

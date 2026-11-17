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
public class PermissaoCampusEntity
{
	private int campusUIDField;

	private bool campusUIDFieldSpecified;

	private string nomeCampusField;

	private long permissaoCampusUIDField;

	private bool permissaoCampusUIDFieldSpecified;

	private long permissaoUIDField;

	private bool permissaoUIDFieldSpecified;

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

	[XmlIgnore]
	public bool campusUIDSpecified
	{
		get
		{
			return campusUIDFieldSpecified;
		}
		set
		{
			campusUIDFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string nomeCampus
	{
		get
		{
			return nomeCampusField;
		}
		set
		{
			nomeCampusField = value;
		}
	}

	public long permissaoCampusUID
	{
		get
		{
			return permissaoCampusUIDField;
		}
		set
		{
			permissaoCampusUIDField = value;
		}
	}

	[XmlIgnore]
	public bool permissaoCampusUIDSpecified
	{
		get
		{
			return permissaoCampusUIDFieldSpecified;
		}
		set
		{
			permissaoCampusUIDFieldSpecified = value;
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

	[XmlIgnore]
	public bool permissaoUIDSpecified
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
}

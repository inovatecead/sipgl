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
public class PermissaoUsuarioEntity
{
	private DateTime? dataLimiteField;

	private bool dataLimiteFieldSpecified;

	private PermissaoEntity permissaoField;

	private long permissaoUsuarioUIDField;

	private bool permissaoUsuarioUIDFieldSpecified;

	private UsuarioEntity usuarioField;

	[XmlElement(IsNullable = true)]
	public DateTime? DataLimite
	{
		get
		{
			return dataLimiteField;
		}
		set
		{
			dataLimiteField = value;
		}
	}

	[XmlIgnore]
	public bool DataLimiteSpecified
	{
		get
		{
			return dataLimiteFieldSpecified;
		}
		set
		{
			dataLimiteFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public PermissaoEntity Permissao
	{
		get
		{
			return permissaoField;
		}
		set
		{
			permissaoField = value;
		}
	}

	public long PermissaoUsuarioUID
	{
		get
		{
			return permissaoUsuarioUIDField;
		}
		set
		{
			permissaoUsuarioUIDField = value;
		}
	}

	[XmlIgnore]
	public bool PermissaoUsuarioUIDSpecified
	{
		get
		{
			return permissaoUsuarioUIDFieldSpecified;
		}
		set
		{
			permissaoUsuarioUIDFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public UsuarioEntity Usuario
	{
		get
		{
			return usuarioField;
		}
		set
		{
			usuarioField = value;
		}
	}
}

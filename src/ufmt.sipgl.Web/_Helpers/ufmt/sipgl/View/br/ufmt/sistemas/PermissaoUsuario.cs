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
public class PermissaoUsuario
{
	private DateTime? dataLimiteField;

	private Permissao permissaoField;

	private long permissaoUsuarioUIDField;

	private Usuario usuarioField;

	[XmlElement(IsNullable = true)]
	public DateTime? dataLimite
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

	[XmlElement(IsNullable = true)]
	public Permissao permissao
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

	public long permissaoUsuarioUID
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

	[XmlElement(IsNullable = true)]
	public Usuario usuario
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

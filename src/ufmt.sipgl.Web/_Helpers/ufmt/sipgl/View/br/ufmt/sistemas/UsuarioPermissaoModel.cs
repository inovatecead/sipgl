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
public class UsuarioPermissaoModel
{
	private DateTime? permissaoDataLimiteField;

	private bool permissaoDataLimiteFieldSpecified;

	private string permissaoDescField;

	private long permissaoIdField;

	private bool permissaoIdFieldSpecified;

	private string permissaoNomeField;

	private long permissaoUsuarioIdField;

	private bool permissaoUsuarioIdFieldSpecified;

	private long pessoaIdField;

	private bool pessoaIdFieldSpecified;

	private long usuarioIdField;

	private bool usuarioIdFieldSpecified;

	private string usuarioNomeField;

	[XmlElement(IsNullable = true)]
	public DateTime? PermissaoDataLimite
	{
		get
		{
			return permissaoDataLimiteField;
		}
		set
		{
			permissaoDataLimiteField = value;
		}
	}

	[XmlIgnore]
	public bool PermissaoDataLimiteSpecified
	{
		get
		{
			return permissaoDataLimiteFieldSpecified;
		}
		set
		{
			permissaoDataLimiteFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string PermissaoDesc
	{
		get
		{
			return permissaoDescField;
		}
		set
		{
			permissaoDescField = value;
		}
	}

	public long PermissaoId
	{
		get
		{
			return permissaoIdField;
		}
		set
		{
			permissaoIdField = value;
		}
	}

	[XmlIgnore]
	public bool PermissaoIdSpecified
	{
		get
		{
			return permissaoIdFieldSpecified;
		}
		set
		{
			permissaoIdFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string PermissaoNome
	{
		get
		{
			return permissaoNomeField;
		}
		set
		{
			permissaoNomeField = value;
		}
	}

	public long PermissaoUsuarioId
	{
		get
		{
			return permissaoUsuarioIdField;
		}
		set
		{
			permissaoUsuarioIdField = value;
		}
	}

	[XmlIgnore]
	public bool PermissaoUsuarioIdSpecified
	{
		get
		{
			return permissaoUsuarioIdFieldSpecified;
		}
		set
		{
			permissaoUsuarioIdFieldSpecified = value;
		}
	}

	public long PessoaId
	{
		get
		{
			return pessoaIdField;
		}
		set
		{
			pessoaIdField = value;
		}
	}

	[XmlIgnore]
	public bool PessoaIdSpecified
	{
		get
		{
			return pessoaIdFieldSpecified;
		}
		set
		{
			pessoaIdFieldSpecified = value;
		}
	}

	public long UsuarioId
	{
		get
		{
			return usuarioIdField;
		}
		set
		{
			usuarioIdField = value;
		}
	}

	[XmlIgnore]
	public bool UsuarioIdSpecified
	{
		get
		{
			return usuarioIdFieldSpecified;
		}
		set
		{
			usuarioIdFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string UsuarioNome
	{
		get
		{
			return usuarioNomeField;
		}
		set
		{
			usuarioNomeField = value;
		}
	}
}

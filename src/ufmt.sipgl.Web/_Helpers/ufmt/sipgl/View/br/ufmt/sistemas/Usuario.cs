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
public class Usuario
{
	private bool bloqueadoField;

	private DateTime? dataProximaTrocaSenhaField;

	private DateTime? dataUltimoAcessoField;

	private string nomeAcessoField;

	private Pessoa pessoaField;

	private string senhaAcessoField;

	private long usuarioUIDField;

	public bool bloqueado
	{
		get
		{
			return bloqueadoField;
		}
		set
		{
			bloqueadoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public DateTime? dataProximaTrocaSenha
	{
		get
		{
			return dataProximaTrocaSenhaField;
		}
		set
		{
			dataProximaTrocaSenhaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public DateTime? dataUltimoAcesso
	{
		get
		{
			return dataUltimoAcessoField;
		}
		set
		{
			dataUltimoAcessoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string nomeAcesso
	{
		get
		{
			return nomeAcessoField;
		}
		set
		{
			nomeAcessoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public Pessoa pessoa
	{
		get
		{
			return pessoaField;
		}
		set
		{
			pessoaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string senhaAcesso
	{
		get
		{
			return senhaAcessoField;
		}
		set
		{
			senhaAcessoField = value;
		}
	}

	public long usuarioUID
	{
		get
		{
			return usuarioUIDField;
		}
		set
		{
			usuarioUIDField = value;
		}
	}
}

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
public class UsuarioEntity
{
	private bool bloqueadoField;

	private bool bloqueadoFieldSpecified;

	private DateTime? dataProximaTrocaSenhaField;

	private bool dataProximaTrocaSenhaFieldSpecified;

	private DateTime? dataUltimoAcessoField;

	private bool dataUltimoAcessoFieldSpecified;

	private string nomeAcessoField;

	private PessoaEntity pessoaField;

	private string regimeJuridicoSiglaField;

	private string registroField;

	private long usuarioUIDField;

	private bool usuarioUIDFieldSpecified;

	public bool Bloqueado
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

	[XmlIgnore]
	public bool BloqueadoSpecified
	{
		get
		{
			return bloqueadoFieldSpecified;
		}
		set
		{
			bloqueadoFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public DateTime? DataProximaTrocaSenha
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

	[XmlIgnore]
	public bool DataProximaTrocaSenhaSpecified
	{
		get
		{
			return dataProximaTrocaSenhaFieldSpecified;
		}
		set
		{
			dataProximaTrocaSenhaFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public DateTime? DataUltimoAcesso
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

	[XmlIgnore]
	public bool DataUltimoAcessoSpecified
	{
		get
		{
			return dataUltimoAcessoFieldSpecified;
		}
		set
		{
			dataUltimoAcessoFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string NomeAcesso
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
	public PessoaEntity Pessoa
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
	public string RegimeJuridicoSigla
	{
		get
		{
			return regimeJuridicoSiglaField;
		}
		set
		{
			regimeJuridicoSiglaField = value;
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

	public long UsuarioUID
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

	[XmlIgnore]
	public bool UsuarioUIDSpecified
	{
		get
		{
			return usuarioUIDFieldSpecified;
		}
		set
		{
			usuarioUIDFieldSpecified = value;
		}
	}
}

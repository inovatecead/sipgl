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
public class PessoaEntity : Pessoa
{
	private string cargoField;

	private byte[] imagemPerfilField;

	private string linkLattesField;

	private string nivelPadraoField;

	private string regimeJuridicoField;

	private long servidorUIDField;

	private bool servidorUIDFieldSpecified;

	private string siapeField;

	private Tipo tipoPessoaField;

	private bool tipoPessoaFieldSpecified;

	private UnidadeEntity unidadeField;

	private SituacaoDoServidor situacaoDoServidorField;

	private bool situacaoDoServidorFieldSpecified;

	[XmlElement(IsNullable = true)]
	public string Cargo
	{
		get
		{
			return cargoField;
		}
		set
		{
			cargoField = value;
		}
	}

	[XmlElement(DataType = "base64Binary", IsNullable = true)]
	public byte[] ImagemPerfil
	{
		get
		{
			return imagemPerfilField;
		}
		set
		{
			imagemPerfilField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string LinkLattes
	{
		get
		{
			return linkLattesField;
		}
		set
		{
			linkLattesField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string NivelPadrao
	{
		get
		{
			return nivelPadraoField;
		}
		set
		{
			nivelPadraoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string RegimeJuridico
	{
		get
		{
			return regimeJuridicoField;
		}
		set
		{
			regimeJuridicoField = value;
		}
	}

	public long ServidorUID
	{
		get
		{
			return servidorUIDField;
		}
		set
		{
			servidorUIDField = value;
		}
	}

	[XmlIgnore]
	public bool ServidorUIDSpecified
	{
		get
		{
			return servidorUIDFieldSpecified;
		}
		set
		{
			servidorUIDFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Siape
	{
		get
		{
			return siapeField;
		}
		set
		{
			siapeField = value;
		}
	}

	public Tipo TipoPessoa
	{
		get
		{
			return tipoPessoaField;
		}
		set
		{
			tipoPessoaField = value;
		}
	}

	[XmlIgnore]
	public bool TipoPessoaSpecified
	{
		get
		{
			return tipoPessoaFieldSpecified;
		}
		set
		{
			tipoPessoaFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public UnidadeEntity Unidade
	{
		get
		{
			return unidadeField;
		}
		set
		{
			unidadeField = value;
		}
	}

	public SituacaoDoServidor situacaoDoServidor
	{
		get
		{
			return situacaoDoServidorField;
		}
		set
		{
			situacaoDoServidorField = value;
		}
	}

	[XmlIgnore]
	public bool situacaoDoServidorSpecified
	{
		get
		{
			return situacaoDoServidorFieldSpecified;
		}
		set
		{
			situacaoDoServidorFieldSpecified = value;
		}
	}
}

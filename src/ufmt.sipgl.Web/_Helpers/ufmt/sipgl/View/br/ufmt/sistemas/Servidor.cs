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
public class Servidor
{
	private int? aposentadoriaAnoPrevistoField;

	private string aposentadoriaNumeroProcessoField;

	private int? aposentadoriaOpcaoIntegralField;

	private Cargo cargoField;

	private int? cargoClasseField;

	private string cargoReferenciaNivelPadraoField;

	private JornadaTrabalho jornadaTrabalhoField;

	private Pessoa pessoaField;

	private string regimeJuridicoField;

	private string registroField;

	private int registroDVField;

	private long servidorUIDField;

	private SituacaoServidor situacaoServidorField;

	private int tipoRegistroField;

	private Unidade unidadeLotacaoField;

	[XmlElement(IsNullable = true)]
	public int? aposentadoriaAnoPrevisto
	{
		get
		{
			return aposentadoriaAnoPrevistoField;
		}
		set
		{
			aposentadoriaAnoPrevistoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string aposentadoriaNumeroProcesso
	{
		get
		{
			return aposentadoriaNumeroProcessoField;
		}
		set
		{
			aposentadoriaNumeroProcessoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public int? aposentadoriaOpcaoIntegral
	{
		get
		{
			return aposentadoriaOpcaoIntegralField;
		}
		set
		{
			aposentadoriaOpcaoIntegralField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public Cargo cargo
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

	[XmlElement(IsNullable = true)]
	public int? cargoClasse
	{
		get
		{
			return cargoClasseField;
		}
		set
		{
			cargoClasseField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string cargoReferenciaNivelPadrao
	{
		get
		{
			return cargoReferenciaNivelPadraoField;
		}
		set
		{
			cargoReferenciaNivelPadraoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public JornadaTrabalho jornadaTrabalho
	{
		get
		{
			return jornadaTrabalhoField;
		}
		set
		{
			jornadaTrabalhoField = value;
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
	public string regimeJuridico
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

	[XmlElement(IsNullable = true)]
	public string registro
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

	public int registroDV
	{
		get
		{
			return registroDVField;
		}
		set
		{
			registroDVField = value;
		}
	}

	public long servidorUID
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

	[XmlElement(IsNullable = true)]
	public SituacaoServidor situacaoServidor
	{
		get
		{
			return situacaoServidorField;
		}
		set
		{
			situacaoServidorField = value;
		}
	}

	public int tipoRegistro
	{
		get
		{
			return tipoRegistroField;
		}
		set
		{
			tipoRegistroField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public Unidade unidadeLotacao
	{
		get
		{
			return unidadeLotacaoField;
		}
		set
		{
			unidadeLotacaoField = value;
		}
	}
}

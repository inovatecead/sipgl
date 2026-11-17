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
public class Unidade
{
	private int ativaField;

	private Campus campusField;

	private string hierarquiaField;

	private string nomeField;

	private string siglaField;

	private TipoUnidadeEnum tipoUnidadeField;

	private Unidade unidadeSuperiorField;

	private long unidadeUIDField;

	public int ativa
	{
		get
		{
			return ativaField;
		}
		set
		{
			ativaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public Campus campus
	{
		get
		{
			return campusField;
		}
		set
		{
			campusField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string hierarquia
	{
		get
		{
			return hierarquiaField;
		}
		set
		{
			hierarquiaField = value;
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

	[XmlElement(IsNullable = true)]
	public string sigla
	{
		get
		{
			return siglaField;
		}
		set
		{
			siglaField = value;
		}
	}

	public TipoUnidadeEnum tipoUnidade
	{
		get
		{
			return tipoUnidadeField;
		}
		set
		{
			tipoUnidadeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public Unidade unidadeSuperior
	{
		get
		{
			return unidadeSuperiorField;
		}
		set
		{
			unidadeSuperiorField = value;
		}
	}

	public long unidadeUID
	{
		get
		{
			return unidadeUIDField;
		}
		set
		{
			unidadeUIDField = value;
		}
	}
}

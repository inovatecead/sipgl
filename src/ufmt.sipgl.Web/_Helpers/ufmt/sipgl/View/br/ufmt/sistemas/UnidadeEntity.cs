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
public class UnidadeEntity
{
	private int ativaField;

	private bool ativaFieldSpecified;

	private string campusField;

	private long campusUIDField;

	private bool campusUIDFieldSpecified;

	private string hierarquiaField;

	private string nomeField;

	private string siglaField;

	private int tipoUnidadeField;

	private bool tipoUnidadeFieldSpecified;

	private long unidadeSuperiorUIDField;

	private bool unidadeSuperiorUIDFieldSpecified;

	private long unidadeUIDField;

	private bool unidadeUIDFieldSpecified;

	public int Ativa
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

	[XmlIgnore]
	public bool AtivaSpecified
	{
		get
		{
			return ativaFieldSpecified;
		}
		set
		{
			ativaFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Campus
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

	public long CampusUID
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
	public bool CampusUIDSpecified
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
	public string Hierarquia
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
	public string Nome
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
	public string Sigla
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

	public int TipoUnidade
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

	[XmlIgnore]
	public bool TipoUnidadeSpecified
	{
		get
		{
			return tipoUnidadeFieldSpecified;
		}
		set
		{
			tipoUnidadeFieldSpecified = value;
		}
	}

	public long UnidadeSuperiorUID
	{
		get
		{
			return unidadeSuperiorUIDField;
		}
		set
		{
			unidadeSuperiorUIDField = value;
		}
	}

	[XmlIgnore]
	public bool UnidadeSuperiorUIDSpecified
	{
		get
		{
			return unidadeSuperiorUIDFieldSpecified;
		}
		set
		{
			unidadeSuperiorUIDFieldSpecified = value;
		}
	}

	public long UnidadeUID
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

	[XmlIgnore]
	public bool UnidadeUIDSpecified
	{
		get
		{
			return unidadeUIDFieldSpecified;
		}
		set
		{
			unidadeUIDFieldSpecified = value;
		}
	}
}

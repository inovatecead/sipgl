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
public class Coordenador
{
	private int campusUIDField;

	private bool campusUIDFieldSpecified;

	private int codigoCursoField;

	private bool codigoCursoFieldSpecified;

	private int coordenadorUIDField;

	private bool coordenadorUIDFieldSpecified;

	private string emailField;

	private string nomeField;

	private long? siapeField;

	private bool siapeFieldSpecified;

	private string usuarioField;

	private string cpfField;

	public int CampusUID
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

	public int CodigoCurso
	{
		get
		{
			return codigoCursoField;
		}
		set
		{
			codigoCursoField = value;
		}
	}

	[XmlIgnore]
	public bool CodigoCursoSpecified
	{
		get
		{
			return codigoCursoFieldSpecified;
		}
		set
		{
			codigoCursoFieldSpecified = value;
		}
	}

	public int CoordenadorUID
	{
		get
		{
			return coordenadorUIDField;
		}
		set
		{
			coordenadorUIDField = value;
		}
	}

	[XmlIgnore]
	public bool CoordenadorUIDSpecified
	{
		get
		{
			return coordenadorUIDFieldSpecified;
		}
		set
		{
			coordenadorUIDFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
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
	public long? Siape
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

	[XmlIgnore]
	public bool SiapeSpecified
	{
		get
		{
			return siapeFieldSpecified;
		}
		set
		{
			siapeFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Usuario
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

	[XmlElement(IsNullable = true)]
	public string cpf
	{
		get
		{
			return cpfField;
		}
		set
		{
			cpfField = value;
		}
	}
}

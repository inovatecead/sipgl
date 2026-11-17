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
public class Aluno
{
	private string agenciaField;

	private string cEPField;

	private int? campusUIDField;

	private bool campusUIDFieldSpecified;

	private string chaveField;

	private string cidadeField;

	private string codigoBancoField;

	private int codigoCursoField;

	private bool codigoCursoFieldSpecified;

	private string cpfField;

	private string cursoField;

	private int cursoUIDField;

	private bool cursoUIDFieldSpecified;

	private DateTime dataNascimentoField;

	private bool dataNascimentoFieldSpecified;

	private string emailField;

	private string enderecoField;

	private string maeAlunoField;

	private decimal matriculaField;

	private bool matriculaFieldSpecified;

	private string nacionalidadeField;

	private string nomeAlunoField;

	private string nomeBancoField;

	private string nomeCampusField;

	private string numeroContaField;

	private string paiAlunoField;

	private string regimeField;

	private string regimeJuridicoSiglaField;

	private string registroField;

	private string rgField;

	private string rgaField;

	private string semestreField;

	private string sexoField;

	private string situacaoField;

	private string telefoneField;

	private string telefoneSecundarioField;

	private string tipoGraduacaoField;

	private string turnoField;

	private string ufField;

	private string anoField;

	private TipoEstudante tipoEstudanteField;

	private bool tipoEstudanteFieldSpecified;

	[XmlElement(IsNullable = true)]
	public string Agencia
	{
		get
		{
			return agenciaField;
		}
		set
		{
			agenciaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string CEP
	{
		get
		{
			return cEPField;
		}
		set
		{
			cEPField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public int? CampusUID
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
	public string Chave
	{
		get
		{
			return chaveField;
		}
		set
		{
			chaveField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Cidade
	{
		get
		{
			return cidadeField;
		}
		set
		{
			cidadeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string CodigoBanco
	{
		get
		{
			return codigoBancoField;
		}
		set
		{
			codigoBancoField = value;
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

	[XmlElement(IsNullable = true)]
	public string Cpf
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

	[XmlElement(IsNullable = true)]
	public string Curso
	{
		get
		{
			return cursoField;
		}
		set
		{
			cursoField = value;
		}
	}

	public int CursoUID
	{
		get
		{
			return cursoUIDField;
		}
		set
		{
			cursoUIDField = value;
		}
	}

	[XmlIgnore]
	public bool CursoUIDSpecified
	{
		get
		{
			return cursoUIDFieldSpecified;
		}
		set
		{
			cursoUIDFieldSpecified = value;
		}
	}

	public DateTime DataNascimento
	{
		get
		{
			return dataNascimentoField;
		}
		set
		{
			dataNascimentoField = value;
		}
	}

	[XmlIgnore]
	public bool DataNascimentoSpecified
	{
		get
		{
			return dataNascimentoFieldSpecified;
		}
		set
		{
			dataNascimentoFieldSpecified = value;
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
	public string Endereco
	{
		get
		{
			return enderecoField;
		}
		set
		{
			enderecoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string MaeAluno
	{
		get
		{
			return maeAlunoField;
		}
		set
		{
			maeAlunoField = value;
		}
	}

	public decimal Matricula
	{
		get
		{
			return matriculaField;
		}
		set
		{
			matriculaField = value;
		}
	}

	[XmlIgnore]
	public bool MatriculaSpecified
	{
		get
		{
			return matriculaFieldSpecified;
		}
		set
		{
			matriculaFieldSpecified = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Nacionalidade
	{
		get
		{
			return nacionalidadeField;
		}
		set
		{
			nacionalidadeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string NomeAluno
	{
		get
		{
			return nomeAlunoField;
		}
		set
		{
			nomeAlunoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string NomeBanco
	{
		get
		{
			return nomeBancoField;
		}
		set
		{
			nomeBancoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string NomeCampus
	{
		get
		{
			return nomeCampusField;
		}
		set
		{
			nomeCampusField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string NumeroConta
	{
		get
		{
			return numeroContaField;
		}
		set
		{
			numeroContaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string PaiAluno
	{
		get
		{
			return paiAlunoField;
		}
		set
		{
			paiAlunoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Regime
	{
		get
		{
			return regimeField;
		}
		set
		{
			regimeField = value;
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

	[XmlElement(IsNullable = true)]
	public string Rg
	{
		get
		{
			return rgField;
		}
		set
		{
			rgField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Rga
	{
		get
		{
			return rgaField;
		}
		set
		{
			rgaField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Semestre
	{
		get
		{
			return semestreField;
		}
		set
		{
			semestreField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Sexo
	{
		get
		{
			return sexoField;
		}
		set
		{
			sexoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Situacao
	{
		get
		{
			return situacaoField;
		}
		set
		{
			situacaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Telefone
	{
		get
		{
			return telefoneField;
		}
		set
		{
			telefoneField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string TelefoneSecundario
	{
		get
		{
			return telefoneSecundarioField;
		}
		set
		{
			telefoneSecundarioField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string TipoGraduacao
	{
		get
		{
			return tipoGraduacaoField;
		}
		set
		{
			tipoGraduacaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string Turno
	{
		get
		{
			return turnoField;
		}
		set
		{
			turnoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string UF
	{
		get
		{
			return ufField;
		}
		set
		{
			ufField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string ano
	{
		get
		{
			return anoField;
		}
		set
		{
			anoField = value;
		}
	}

	public TipoEstudante tipoEstudante
	{
		get
		{
			return tipoEstudanteField;
		}
		set
		{
			tipoEstudanteField = value;
		}
	}

	[XmlIgnore]
	public bool tipoEstudanteSpecified
	{
		get
		{
			return tipoEstudanteFieldSpecified;
		}
		set
		{
			tipoEstudanteFieldSpecified = value;
		}
	}
}

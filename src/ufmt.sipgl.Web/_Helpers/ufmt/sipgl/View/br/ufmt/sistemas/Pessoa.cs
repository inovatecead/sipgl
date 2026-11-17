using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[Serializable]
[XmlInclude(typeof(PessoaEntity))]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
public class Pessoa
{
	private string cpfField;

	private string ctpsField;

	private string ctpsSerieField;

	private string ctpsUfField;

	private string enderecoBairroField;

	private string enderecoCepField;

	private string enderecoComplementoField;

	private string enderecoLogradouroField;

	private string enderecoMunicipioField;

	private string enderecoNumeroField;

	private string enderecoUfField;

	private string mailField;

	private DateTime nascimentoDataField;

	private string nomeField;

	private string nomeMaeField;

	private string nomePaiField;

	private long pessoaUIDField;

	private string pisPasepField;

	private string rgField;

	private DateTime? rgDataExpedicaoField;

	private string rgOrgaoExpedidorField;

	private string rgUfField;

	private int sexoField;

	private string telefoneComercialField;

	private string telefonePrimarioField;

	private string telefoneSecundarioField;

	private TipoTitulacao tipoTitulacaoField;

	private string tituloEleitorField;

	private DateTime? tituloEleitorDataEmissaoField;

	private string tituloEleitorSecaoField;

	private string tituloEleitorUfField;

	private string tituloEleitorZonaField;

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

	[XmlElement(IsNullable = true)]
	public string ctps
	{
		get
		{
			return ctpsField;
		}
		set
		{
			ctpsField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string ctpsSerie
	{
		get
		{
			return ctpsSerieField;
		}
		set
		{
			ctpsSerieField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string ctpsUf
	{
		get
		{
			return ctpsUfField;
		}
		set
		{
			ctpsUfField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoBairro
	{
		get
		{
			return enderecoBairroField;
		}
		set
		{
			enderecoBairroField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoCep
	{
		get
		{
			return enderecoCepField;
		}
		set
		{
			enderecoCepField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoComplemento
	{
		get
		{
			return enderecoComplementoField;
		}
		set
		{
			enderecoComplementoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoLogradouro
	{
		get
		{
			return enderecoLogradouroField;
		}
		set
		{
			enderecoLogradouroField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoMunicipio
	{
		get
		{
			return enderecoMunicipioField;
		}
		set
		{
			enderecoMunicipioField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoNumero
	{
		get
		{
			return enderecoNumeroField;
		}
		set
		{
			enderecoNumeroField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string enderecoUf
	{
		get
		{
			return enderecoUfField;
		}
		set
		{
			enderecoUfField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string mail
	{
		get
		{
			return mailField;
		}
		set
		{
			mailField = value;
		}
	}

	public DateTime nascimentoData
	{
		get
		{
			return nascimentoDataField;
		}
		set
		{
			nascimentoDataField = value;
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
	public string nomeMae
	{
		get
		{
			return nomeMaeField;
		}
		set
		{
			nomeMaeField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string nomePai
	{
		get
		{
			return nomePaiField;
		}
		set
		{
			nomePaiField = value;
		}
	}

	public long pessoaUID
	{
		get
		{
			return pessoaUIDField;
		}
		set
		{
			pessoaUIDField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string pisPasep
	{
		get
		{
			return pisPasepField;
		}
		set
		{
			pisPasepField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string rg
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
	public DateTime? rgDataExpedicao
	{
		get
		{
			return rgDataExpedicaoField;
		}
		set
		{
			rgDataExpedicaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string rgOrgaoExpedidor
	{
		get
		{
			return rgOrgaoExpedidorField;
		}
		set
		{
			rgOrgaoExpedidorField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string rgUf
	{
		get
		{
			return rgUfField;
		}
		set
		{
			rgUfField = value;
		}
	}

	public int sexo
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
	public string telefoneComercial
	{
		get
		{
			return telefoneComercialField;
		}
		set
		{
			telefoneComercialField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string telefonePrimario
	{
		get
		{
			return telefonePrimarioField;
		}
		set
		{
			telefonePrimarioField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string telefoneSecundario
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
	public TipoTitulacao tipoTitulacao
	{
		get
		{
			return tipoTitulacaoField;
		}
		set
		{
			tipoTitulacaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string tituloEleitor
	{
		get
		{
			return tituloEleitorField;
		}
		set
		{
			tituloEleitorField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public DateTime? tituloEleitorDataEmissao
	{
		get
		{
			return tituloEleitorDataEmissaoField;
		}
		set
		{
			tituloEleitorDataEmissaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string tituloEleitorSecao
	{
		get
		{
			return tituloEleitorSecaoField;
		}
		set
		{
			tituloEleitorSecaoField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string tituloEleitorUf
	{
		get
		{
			return tituloEleitorUfField;
		}
		set
		{
			tituloEleitorUfField = value;
		}
	}

	[XmlElement(IsNullable = true)]
	public string tituloEleitorZona
	{
		get
		{
			return tituloEleitorZonaField;
		}
		set
		{
			tituloEleitorZonaField = value;
		}
	}
}

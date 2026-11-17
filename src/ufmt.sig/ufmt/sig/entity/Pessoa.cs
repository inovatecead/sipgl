using System;

namespace ufmt.sig.entity;

[Serializable]
public class Pessoa
{
	private long pessoaUID;

	private string nome;

	private char sexo;

	private DateTime nascimentoData;

	private string nomeMae;

	private string nomePai;

	private string cpf;

	private string pisPasep;

	private string ctps;

	private string ctpsSerie;

	private string ctpsUf;

	private string rg;

	private string rgOrgaoExpedidor;

	private DateTime? rgDataExpedicao;

	private string rgUf;

	private string tituloEleitor;

	private string tituloEleitorZona;

	private string tituloEleitorSecao;

	private DateTime? tituloEleitorDataEmissao;

	private string tituloEleitorUf;

	private string enderecoLogradouro;

	private string enderecoNumero;

	private string enderecoComplemento;

	private string enderecoBairro;

	private string enderecoMunicipio;

	private string enderecoUf;

	private string enderecoCep;

	private string telefonePrimario;

	private string telefoneSecundario;

	private string telefoneComercial;

	private string mail;

	private TipoTitulacao tipoTitulacao;

	public virtual long PessoaUID
	{
		get
		{
			return pessoaUID;
		}
		set
		{
			pessoaUID = value;
		}
	}

	public virtual string Nome
	{
		get
		{
			return nome;
		}
		set
		{
			nome = value;
		}
	}

	public virtual char Sexo
	{
		get
		{
			return sexo;
		}
		set
		{
			if (!'M'.Equals(char.ToUpper(value)) && !'F'.Equals(char.ToUpper(value)))
			{
				throw new Exception(string.Format("Sexo esperado 'M' ou 'F'. Valor recebido %s", value));
			}
			sexo = char.ToUpper(value);
		}
	}

	public virtual DateTime NascimentoData
	{
		get
		{
			return nascimentoData;
		}
		set
		{
			nascimentoData = value;
		}
	}

	public virtual string NomeMae
	{
		get
		{
			return nomeMae;
		}
		set
		{
			nomeMae = value;
		}
	}

	public virtual string NomePai
	{
		get
		{
			return nomePai;
		}
		set
		{
			nomePai = value;
		}
	}

	public virtual string Cpf
	{
		get
		{
			return cpf;
		}
		set
		{
			cpf = value;
		}
	}

	public virtual string PisPasep
	{
		get
		{
			return pisPasep;
		}
		set
		{
			pisPasep = value;
		}
	}

	public virtual string Ctps
	{
		get
		{
			return ctps;
		}
		set
		{
			ctps = value;
		}
	}

	public virtual string CtpsSerie
	{
		get
		{
			return ctpsSerie;
		}
		set
		{
			ctpsSerie = value;
		}
	}

	public virtual string CtpsUf
	{
		get
		{
			return ctpsUf;
		}
		set
		{
			ctpsUf = value;
		}
	}

	public virtual string Rg
	{
		get
		{
			return rg;
		}
		set
		{
			rg = value;
		}
	}

	public virtual string RgOrgaoExpedidor
	{
		get
		{
			return rgOrgaoExpedidor;
		}
		set
		{
			rgOrgaoExpedidor = value;
		}
	}

	public virtual DateTime? RgDataExpedicao
	{
		get
		{
			return rgDataExpedicao;
		}
		set
		{
			rgDataExpedicao = value;
		}
	}

	public virtual string RgUf
	{
		get
		{
			return rgUf;
		}
		set
		{
			rgUf = value;
		}
	}

	public virtual string TituloEleitor
	{
		get
		{
			return tituloEleitor;
		}
		set
		{
			tituloEleitor = value;
		}
	}

	public virtual string TituloEleitorZona
	{
		get
		{
			return tituloEleitorZona;
		}
		set
		{
			tituloEleitorZona = value;
		}
	}

	public virtual string TituloEleitorSecao
	{
		get
		{
			return tituloEleitorSecao;
		}
		set
		{
			tituloEleitorSecao = value;
		}
	}

	public virtual DateTime? TituloEleitorDataEmissao
	{
		get
		{
			return tituloEleitorDataEmissao;
		}
		set
		{
			tituloEleitorDataEmissao = value;
		}
	}

	public virtual string TituloEleitorUf
	{
		get
		{
			return tituloEleitorUf;
		}
		set
		{
			tituloEleitorUf = value;
		}
	}

	public virtual string EnderecoLogradouro
	{
		get
		{
			return enderecoLogradouro;
		}
		set
		{
			enderecoLogradouro = value;
		}
	}

	public virtual string EnderecoNumero
	{
		get
		{
			return enderecoNumero;
		}
		set
		{
			enderecoNumero = value;
		}
	}

	public virtual string EnderecoComplemento
	{
		get
		{
			return enderecoComplemento;
		}
		set
		{
			enderecoComplemento = value;
		}
	}

	public virtual string EnderecoBairro
	{
		get
		{
			return enderecoBairro;
		}
		set
		{
			enderecoBairro = value;
		}
	}

	public virtual string EnderecoMunicipio
	{
		get
		{
			return enderecoMunicipio;
		}
		set
		{
			enderecoMunicipio = value;
		}
	}

	public virtual string EnderecoUf
	{
		get
		{
			return enderecoUf;
		}
		set
		{
			enderecoUf = value;
		}
	}

	public virtual string EnderecoCep
	{
		get
		{
			return enderecoCep;
		}
		set
		{
			enderecoCep = value;
		}
	}

	public virtual string TelefonePrimario
	{
		get
		{
			return telefonePrimario;
		}
		set
		{
			telefonePrimario = value;
		}
	}

	public virtual string TelefoneSecundario
	{
		get
		{
			return telefoneSecundario;
		}
		set
		{
			telefoneSecundario = value;
		}
	}

	public virtual string TelefoneComercial
	{
		get
		{
			return telefoneComercial;
		}
		set
		{
			telefoneComercial = value;
		}
	}

	public virtual string Mail
	{
		get
		{
			return mail;
		}
		set
		{
			mail = value;
		}
	}

	public virtual TipoTitulacao TipoTitulacao
	{
		get
		{
			return tipoTitulacao;
		}
		set
		{
			tipoTitulacao = value;
		}
	}
}

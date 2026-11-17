using System;

namespace ufmt.sig.entity;

[Serializable]
public class Servidor
{
	private long servidorUID;

	private Pessoa pessoa;

	private string registro;

	private char registroDV;

	private char tipoRegistro;

	private string regimeJuridico;

	private JornadaTrabalho jornadaTrabalho;

	private Cargo cargo;

	private char? cargoClasse;

	private string cargoReferenciaNivelPadrao;

	private Unidade unidadeLotacao;

	private string aposentadoriaNumeroProcesso;

	private int? aposentadoriaAnoPrevisto;

	private char? aposentadoriaOpcaoIntegral;

	private SituacaoServidor situacaoServidor;

	public virtual long ServidorUID
	{
		get
		{
			return servidorUID;
		}
		set
		{
			servidorUID = value;
		}
	}

	public virtual Pessoa Pessoa
	{
		get
		{
			return pessoa;
		}
		set
		{
			pessoa = value;
		}
	}

	public virtual string Registro
	{
		get
		{
			return registro;
		}
		set
		{
			registro = value;
		}
	}

	public virtual char RegistroDV
	{
		get
		{
			return registroDV;
		}
		set
		{
			registroDV = value;
		}
	}

	public virtual char TipoRegistro
	{
		get
		{
			return tipoRegistro;
		}
		set
		{
			if (string.IsNullOrEmpty(value.ToString()))
			{
				throw new Exception("Tipo registro não pode ser vazio");
			}
			tipoRegistro = char.ToUpper(value);
		}
	}

	public virtual string RegimeJuridico
	{
		get
		{
			return regimeJuridico;
		}
		set
		{
			regimeJuridico = value;
		}
	}

	public virtual JornadaTrabalho JornadaTrabalho
	{
		get
		{
			return jornadaTrabalho;
		}
		set
		{
			jornadaTrabalho = value;
		}
	}

	public virtual Cargo Cargo
	{
		get
		{
			return cargo;
		}
		set
		{
			cargo = value;
		}
	}

	public virtual char? CargoClasse
	{
		get
		{
			return cargoClasse;
		}
		set
		{
			cargoClasse = value;
		}
	}

	public virtual string CargoReferenciaNivelPadrao
	{
		get
		{
			return cargoReferenciaNivelPadrao;
		}
		set
		{
			cargoReferenciaNivelPadrao = value;
		}
	}

	public virtual Unidade UnidadeLotacao
	{
		get
		{
			return unidadeLotacao;
		}
		set
		{
			unidadeLotacao = value;
		}
	}

	public virtual string AposentadoriaNumeroProcesso
	{
		get
		{
			return aposentadoriaNumeroProcesso;
		}
		set
		{
			aposentadoriaNumeroProcesso = value;
		}
	}

	public virtual int? AposentadoriaAnoPrevisto
	{
		get
		{
			return aposentadoriaAnoPrevisto;
		}
		set
		{
			aposentadoriaAnoPrevisto = value;
		}
	}

	public virtual char? AposentadoriaOpcaoIntegral
	{
		get
		{
			return aposentadoriaOpcaoIntegral;
		}
		set
		{
			if (value.HasValue && !'S'.Equals(char.ToUpper(value.Value)) && !'N'.Equals(char.ToUpper(value.Value)))
			{
				throw new Exception(string.Format("Opção de Aposentadoria Integral esperada 'S' ou 'N'. Valor recebido %s", value));
			}
			aposentadoriaOpcaoIntegral = value;
		}
	}

	public virtual SituacaoServidor SituacaoServidor
	{
		get
		{
			return situacaoServidor;
		}
		set
		{
			situacaoServidor = value;
		}
	}
}

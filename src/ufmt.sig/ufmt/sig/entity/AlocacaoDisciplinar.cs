using System;

namespace ufmt.sig.entity;

[Serializable]
public class AlocacaoDisciplinar
{
	private long alocacaoDisciplinarUID;

	private AlocacaoDisciplinar alocacaoDisciplinarPrincipal;

	private MatrizDisciplinar matrizDisciplinar;

	private Servidor servidorDocente;

	private int ano;

	private short periodo;

	private TipoAlocacaoDisciplinar tipoAlocacaoDisciplinar;

	private int? quantidadeOrientandos;

	private float cargaHoraria;

	private float cargaHorariaSemanal;

	private float coeficientePreparacaoAula;

	private bool fracionada;

	private TipoFracionamentoDisciplinar tipoFracionamentoDisciplinar;

	private string identificacao;

	private string justificativaFracionamento;

	private bool isCoordenadorFracionou;

	private Servidor servidorFracionador;

	public virtual long AlocacaoDisciplinarUID
	{
		get
		{
			return alocacaoDisciplinarUID;
		}
		set
		{
			alocacaoDisciplinarUID = value;
		}
	}

	public virtual AlocacaoDisciplinar AlocacaoDisciplinarPrincipal
	{
		get
		{
			return alocacaoDisciplinarPrincipal;
		}
		set
		{
			alocacaoDisciplinarPrincipal = value;
		}
	}

	public virtual MatrizDisciplinar MatrizDisciplinar
	{
		get
		{
			return matrizDisciplinar;
		}
		set
		{
			matrizDisciplinar = value;
		}
	}

	public virtual Servidor ServidorDocente
	{
		get
		{
			return servidorDocente;
		}
		set
		{
			servidorDocente = value;
		}
	}

	public virtual int Ano
	{
		get
		{
			return ano;
		}
		set
		{
			ano = value;
		}
	}

	public virtual short Periodo
	{
		get
		{
			return periodo;
		}
		set
		{
			periodo = value;
		}
	}

	public virtual TipoAlocacaoDisciplinar TipoAlocacaoDisciplinar
	{
		get
		{
			return tipoAlocacaoDisciplinar;
		}
		set
		{
			tipoAlocacaoDisciplinar = value;
		}
	}

	protected internal virtual int TipoAlocacaoDisciplinarUID
	{
		get
		{
			return tipoAlocacaoDisciplinar.TipoAlocacaoDisciplinarUID;
		}
		set
		{
			tipoAlocacaoDisciplinar = TipoAlocacaoDisciplinar.GetInstance(value);
		}
	}

	public virtual int? QuantidadeOrientandos
	{
		get
		{
			return quantidadeOrientandos;
		}
		set
		{
			quantidadeOrientandos = value;
		}
	}

	public virtual float CargaHoraria
	{
		get
		{
			return cargaHoraria;
		}
		set
		{
			cargaHoraria = value;
		}
	}

	public virtual float CargaHorariaSemanal
	{
		get
		{
			return cargaHorariaSemanal;
		}
		set
		{
			cargaHorariaSemanal = value;
		}
	}

	public virtual float CoeficientePreparacaoAula
	{
		get
		{
			return coeficientePreparacaoAula;
		}
		set
		{
			coeficientePreparacaoAula = value;
		}
	}

	public virtual bool Fracionada
	{
		get
		{
			return fracionada;
		}
		set
		{
			fracionada = value;
		}
	}

	public virtual TipoFracionamentoDisciplinar TipoFracionamentoDisciplinar
	{
		get
		{
			return tipoFracionamentoDisciplinar;
		}
		set
		{
			tipoFracionamentoDisciplinar = value;
		}
	}

	protected internal virtual int? TipoFracionamentoDisciplinarUID
	{
		get
		{
			if (tipoFracionamentoDisciplinar == null)
			{
				return null;
			}
			return tipoFracionamentoDisciplinar.TipoFracionamentoDisciplinarUID;
		}
		set
		{
			tipoFracionamentoDisciplinar = (value.HasValue ? TipoFracionamentoDisciplinar.GetInstance(value.Value) : null);
		}
	}

	public virtual string Identificacao
	{
		get
		{
			return identificacao;
		}
		set
		{
			identificacao = value;
		}
	}

	public virtual string JustificativaFracionamento
	{
		get
		{
			return justificativaFracionamento;
		}
		set
		{
			justificativaFracionamento = value;
		}
	}

	public virtual bool IsCoordenadorFracionou
	{
		get
		{
			return isCoordenadorFracionou;
		}
		set
		{
			isCoordenadorFracionou = value;
		}
	}

	public virtual Servidor ServidorFracionador
	{
		get
		{
			return servidorFracionador;
		}
		set
		{
			servidorFracionador = value;
		}
	}

	public virtual string IdentificacaoCompleta
	{
		get
		{
			string text = ((Identificacao == null) ? "" : Identificacao);
			int num = 0;
			AlocacaoDisciplinar alocacaoDisciplinar = AlocacaoDisciplinarPrincipal;
			while (alocacaoDisciplinar != null)
			{
				if (!string.IsNullOrEmpty(alocacaoDisciplinar.Identificacao))
				{
					text = ((!string.IsNullOrEmpty(text)) ? (alocacaoDisciplinar.Identificacao + " - " + text) : alocacaoDisciplinar.Identificacao);
				}
				alocacaoDisciplinar = alocacaoDisciplinar.AlocacaoDisciplinarPrincipal;
				num++;
				if (num == 1000)
				{
					break;
				}
			}
			return text;
		}
	}
}

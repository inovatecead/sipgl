using System;

namespace ufmt.sig.entity;

[Serializable]
public class DivisaoDisciplinar
{
	private float cargaHoraria;

	private TipoAlocacaoDisciplinar tipoAlocacaoDisciplinar;

	private string identificacao;

	public float CargaHoraria
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

	public TipoAlocacaoDisciplinar TipoAlocacaoDisciplinar
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

	public string Identificacao
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

	public DivisaoDisciplinar()
	{
	}

	public DivisaoDisciplinar(TipoAlocacaoDisciplinar tipoAlocacaoDisciplinar, float cargaHoraria, string identificacao)
	{
		TipoAlocacaoDisciplinar = tipoAlocacaoDisciplinar;
		CargaHoraria = cargaHoraria;
		Identificacao = identificacao;
	}
}

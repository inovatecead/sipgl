using System;

namespace ufmt.sig.entity;

[Serializable]
public class TipoTecnologiaAssistiva
{
	private string tipoTecnologiaAssistivaUID;

	private string descricao;

	public virtual string TipoTecnologiaAssistivaUID
	{
		get
		{
			return tipoTecnologiaAssistivaUID;
		}
		set
		{
			tipoTecnologiaAssistivaUID = value;
		}
	}

	public virtual string Descricao
	{
		get
		{
			return descricao;
		}
		set
		{
			descricao = value;
		}
	}
}

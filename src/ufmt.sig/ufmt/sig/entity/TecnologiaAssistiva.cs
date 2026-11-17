using System;

namespace ufmt.sig.entity;

[Serializable]
public class TecnologiaAssistiva
{
	private long tecnologiaAssistivaUID;

	private Curso curso;

	private TipoTecnologiaAssistiva tipoTecnologiaAssistiva;

	public virtual long TecnologiaAssistivaUID
	{
		get
		{
			return tecnologiaAssistivaUID;
		}
		set
		{
			tecnologiaAssistivaUID = value;
		}
	}

	public virtual Curso Curso
	{
		get
		{
			return curso;
		}
		set
		{
			curso = value;
		}
	}

	public virtual TipoTecnologiaAssistiva TipoTecnologiaAssistiva
	{
		get
		{
			return tipoTecnologiaAssistiva;
		}
		set
		{
			tipoTecnologiaAssistiva = value;
		}
	}
}

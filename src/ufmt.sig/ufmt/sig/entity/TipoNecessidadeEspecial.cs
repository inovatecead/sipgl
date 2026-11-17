using System;

namespace ufmt.sig.entity;

[Serializable]
public class TipoNecessidadeEspecial
{
	private string tipoNecessidadeEspecialUID;

	private string descricao;

	public virtual string TipoNecessidadeEspecialUID
	{
		get
		{
			return tipoNecessidadeEspecialUID;
		}
		set
		{
			tipoNecessidadeEspecialUID = value;
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

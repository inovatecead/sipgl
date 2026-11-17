using System;

namespace ufmt.sig.entity.sge;

[Serializable]
public class UnidadeAlocadora
{
	private long unidadeAlocadoraUID;

	private Unidade unidade;

	public virtual long UnidadeAlocadoraUID
	{
		get
		{
			return unidadeAlocadoraUID;
		}
		set
		{
			unidadeAlocadoraUID = value;
		}
	}

	public virtual Unidade Unidade
	{
		get
		{
			return unidade;
		}
		set
		{
			unidade = value;
		}
	}
}

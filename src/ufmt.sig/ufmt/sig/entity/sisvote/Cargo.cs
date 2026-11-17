namespace ufmt.sig.entity.sisvote;

public class Cargo
{
	private long cargoUID;

	private Eleicao eleicao;

	private Unidade unidade;

	private string descricao;

	public virtual long CargoUID
	{
		get
		{
			return cargoUID;
		}
		set
		{
			cargoUID = value;
		}
	}

	public virtual Eleicao Eleicao
	{
		get
		{
			return eleicao;
		}
		set
		{
			eleicao = value;
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

namespace ufmt.sig.entity.sisvote;

public class TipoVoto
{
	private long tipoVotoUID;

	private string descricao;

	public virtual long TipoVotoUID
	{
		get
		{
			return tipoVotoUID;
		}
		set
		{
			tipoVotoUID = value;
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

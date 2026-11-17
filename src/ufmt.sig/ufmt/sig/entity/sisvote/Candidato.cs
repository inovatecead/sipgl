namespace ufmt.sig.entity.sisvote;

public class Candidato
{
	private long candidatoUID;

	private Cargo cargo;

	private Servidor servidor;

	public virtual long CandidatoUID
	{
		get
		{
			return candidatoUID;
		}
		set
		{
			candidatoUID = value;
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

	public virtual Servidor Servidor
	{
		get
		{
			return servidor;
		}
		set
		{
			servidor = value;
		}
	}
}

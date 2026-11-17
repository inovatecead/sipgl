using System;

namespace ufmt.sig.entity;

[Serializable]
public class PerfilUsuario
{
	private long perfilUsuarioUID;

	private Usuario usuario;

	private Perfil perfil;

	public virtual long PerfilUsuarioUID
	{
		get
		{
			return perfilUsuarioUID;
		}
		set
		{
			perfilUsuarioUID = value;
		}
	}

	public virtual Usuario Usuario
	{
		get
		{
			return usuario;
		}
		set
		{
			usuario = value;
		}
	}

	public virtual Perfil Perfil
	{
		get
		{
			return perfil;
		}
		set
		{
			perfil = value;
		}
	}
}

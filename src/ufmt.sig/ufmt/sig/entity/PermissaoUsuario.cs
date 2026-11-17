using System;

namespace ufmt.sig.entity;

[Serializable]
public class PermissaoUsuario
{
	private long permissaoUsuarioUID;

	private Usuario usuario;

	private Permissao permissao;

	private DateTime? dataLimite;

	public virtual long PermissaoUsuarioUID
	{
		get
		{
			return permissaoUsuarioUID;
		}
		set
		{
			permissaoUsuarioUID = value;
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

	public virtual Permissao Permissao
	{
		get
		{
			return permissao;
		}
		set
		{
			permissao = value;
		}
	}

	public virtual DateTime? DataLimite
	{
		get
		{
			return dataLimite;
		}
		set
		{
			dataLimite = value;
		}
	}
}

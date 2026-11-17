using System;

namespace ufmt.sig.entity;

[Serializable]
public class PermissaoPerfil
{
	private long permissaoPerfilUID;

	private Perfil perfil;

	private Permissao permissao;

	public virtual long PermissaoPerfilUID
	{
		get
		{
			return permissaoPerfilUID;
		}
		set
		{
			permissaoPerfilUID = value;
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
}

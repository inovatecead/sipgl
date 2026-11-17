using System;
using System.Security.Cryptography;
using System.Text;

namespace ufmt.sig.entity;

[Serializable]
public class Usuario
{
	private long usuarioUID;

	private Pessoa pessoa;

	private string nomeAcesso;

	private string senhaAcesso;

	private bool bloqueado;

	private DateTime? dataUltimoAcesso;

	private DateTime? dataProximaTrocaSenha;

	public virtual long UsuarioUID
	{
		get
		{
			return usuarioUID;
		}
		set
		{
			usuarioUID = value;
		}
	}

	public virtual Pessoa Pessoa
	{
		get
		{
			return pessoa;
		}
		set
		{
			pessoa = value;
		}
	}

	public virtual string NomeAcesso
	{
		get
		{
			return nomeAcesso;
		}
		set
		{
			nomeAcesso = value;
		}
	}

	public virtual string SenhaAcesso
	{
		get
		{
			return senhaAcesso;
		}
		set
		{
			senhaAcesso = value;
		}
	}

	public virtual bool Bloqueado
	{
		get
		{
			return bloqueado;
		}
		set
		{
			bloqueado = value;
		}
	}

	public virtual DateTime? DataUltimoAcesso
	{
		get
		{
			return dataUltimoAcesso;
		}
		set
		{
			dataUltimoAcesso = value;
		}
	}

	public virtual DateTime? DataProximaTrocaSenha
	{
		get
		{
			return dataProximaTrocaSenha;
		}
		set
		{
			dataProximaTrocaSenha = value;
		}
	}

	protected internal virtual void SetSenhaAcesso(string novaSenha)
	{
		senhaAcesso = Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("iso-8859-1").GetBytes(novaSenha)));
	}

	protected internal virtual bool CompareSenha(string senhaInformada)
	{
		if (senhaAcesso == null)
		{
			return false;
		}
		return senhaAcesso.Equals(Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("iso-8859-1").GetBytes(senhaInformada))));
	}
}

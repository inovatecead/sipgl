using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class PermissaoDAL
{
	public Permissao BuscarPermissaoPorID(long permissaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().Permissao.Where((Permissao e) => e.permissaoUID == permissaoUID).FirstOrDefault();
		}
		catch (Exception)
		{
			return new Permissao();
		}
	}

	public List<Permissao> ListarPermissoesPorAplicacao(long aplicacaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().Permissao.Where((Permissao e) => e.aplicacaoUID == aplicacaoUID).ToList();
		}
		catch (Exception)
		{
			return new List<Permissao>();
		}
	}

	public List<PermissaoUsuario> ListarPermissoesPorUsuario(long usuarioUID, long aplicacaoUID, bool isAtivas)
	{
		try
		{
			IQueryable<PermissaoUsuario> source = Contexto.GetContextInstance().PermissaoUsuario.AsQueryable();
			source = source.Where((PermissaoUsuario e) => e.usuarioUID == usuarioUID && e.Permissao.aplicacaoUID == aplicacaoUID);
			if (isAtivas)
			{
				source = source.Where((PermissaoUsuario e) => e.dataLimite == null);
			}
			return source.ToList();
		}
		catch (Exception)
		{
			return new List<PermissaoUsuario>();
		}
	}

	public PermissaoUsuario BuscarPermissaoUsuario(long usuarioUID, long permissaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().PermissaoUsuario.Where((PermissaoUsuario e) => e.usuarioUID == usuarioUID && e.permissaoUID == permissaoUID).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public ResultadoOperacao VincularPermissoes(List<long> listaPermissoesSelecionadas, long usuarioUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			foreach (PermissaoUsuario item in ListarPermissoesPorUsuario(usuarioUID, 19L, isAtivas: false))
			{
				if (!listaPermissoesSelecionadas.Contains(item.permissaoUID))
				{
					PermissaoUsuario permissaoUsuario = contextInstance.PermissaoUsuario.Where((PermissaoUsuario e) => e.usuarioUID == usuarioUID && e.permissaoUID == item.permissaoUID).FirstOrDefault();
					permissaoUsuario.dataLimite = DateTime.Now;
					contextInstance.Entry(permissaoUsuario).State = (EntityState)16;
				}
			}
			foreach (long item2 in listaPermissoesSelecionadas)
			{
				PermissaoUsuario permissaoUsuario2 = contextInstance.PermissaoUsuario.Where((PermissaoUsuario e) => e.usuarioUID == usuarioUID && e.permissaoUID == item2).FirstOrDefault();
				if (permissaoUsuario2 == null)
				{
					PermissaoUsuario permissaoUsuario3 = new PermissaoUsuario();
					permissaoUsuario3.usuarioUID = usuarioUID;
					permissaoUsuario3.permissaoUID = item2;
					permissaoUsuario3.dataLimite = null;
					contextInstance.PermissaoUsuario.Add(permissaoUsuario3);
				}
				else
				{
					permissaoUsuario2.dataLimite = null;
					contextInstance.Entry(permissaoUsuario2).State = (EntityState)16;
				}
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Permissões vinculadas com sucesso!";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoRecursoDAL
{
	public List<ProjetoRecurso> ListarRecursos()
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoRecurso.ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoRecurso>();
		}
	}

	public List<ProjetoRecurso> ListarRecursosVinculados(long permissaoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ProjetoPermissaoRecurso
				where e.permissaoUID == permissaoUID
				select e.ProjetoRecurso).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoRecurso>();
		}
	}

	public bool IsRecursoVinculado(long projetoRecursoUID, long permissaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoPermissaoRecurso.Where((ProjetoPermissaoRecurso e) => e.projetoRecursoUID == projetoRecursoUID && e.permissaoUID == permissaoUID).Any();
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<ProjetoRecurso> ListarRecursosPorPerfil(long permissaoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ProjetoPermissaoRecurso
				where e.permissaoUID == permissaoUID
				select e.ProjetoRecurso).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoRecurso>();
		}
	}

	public List<ProjetoRecurso> ListarRecursosPorPerfis(List<long> listaPermissaoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ProjetoPermissaoRecurso
				where listaPermissaoUID.Contains(e.permissaoUID)
				select e.ProjetoRecurso).Distinct().ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoRecurso>();
		}
	}

	public ResultadoOperacao VincularRecurso(long projetoRecursoUID, long permissaoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (IsRecursoVinculado(projetoRecursoUID, permissaoUID))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O recurso selecionado já se encontra vinculado ao perfil.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoPermissaoRecurso projetoPermissaoRecurso = new ProjetoPermissaoRecurso();
			projetoPermissaoRecurso.permissaoUID = permissaoUID;
			projetoPermissaoRecurso.projetoRecursoUID = projetoRecursoUID;
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			contextInstance.ProjetoPermissaoRecurso.Add(projetoPermissaoRecurso);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Recurso vinculado com sucesso!";
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

	public ResultadoOperacao DesvincularRecurso(long projetoRecursoUID, long permissaoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (!IsRecursoVinculado(projetoRecursoUID, permissaoUID))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível desvincular o recurso selecionado pois o mesmo não se encontra vinculado ao perfil.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoPermissaoRecurso entity = contextInstance.ProjetoPermissaoRecurso.Where((ProjetoPermissaoRecurso e) => e.projetoRecursoUID == projetoRecursoUID && e.permissaoUID == permissaoUID).FirstOrDefault();
			contextInstance.ProjetoPermissaoRecurso.Remove(entity);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Recurso desvinculado com sucesso!";
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

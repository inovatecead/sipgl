using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class UsuarioDAL
{
	public Usuario BuscarUsuarioPorID(long usuarioUID)
	{
		try
		{
			return Contexto.GetContextInstance().Usuario.Where((Usuario e) => e.usuarioUID == usuarioUID).Include((Usuario e) => e.Pessoa).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public List<Usuario> FiltrarUsuarios(string nome, string cpf, long permissaoUID)
	{
		try
		{
			IQueryable<Usuario> source = Contexto.GetContextInstance().Usuario.AsQueryable();
			if (!string.IsNullOrWhiteSpace(nome))
			{
				source = source.Where((Usuario e) => e.Pessoa.nome.ToUpper().Contains(nome.ToUpper()));
			}
			if (!string.IsNullOrWhiteSpace(cpf))
			{
				cpf = cpf.Replace(".", "");
				cpf = cpf.Replace("-", "");
				source = source.Where((Usuario e) => e.Pessoa.cpf == cpf);
			}
			if (permissaoUID > 0)
			{
				source = source.Where((Usuario e) => e.PermissaoUsuario.Any((PermissaoUsuario t) => t.permissaoUID == permissaoUID && t.dataLimite == null));
			}
			return source.OrderBy((Usuario e) => e.Pessoa.nome).Include((Usuario e) => e.Pessoa).ToList();
		}
		catch (Exception)
		{
			return new List<Usuario>();
		}
	}

	public ProjetoUsuarioUnidade BuscarVinculoUsuarioUnidade(long usuarioUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoUsuarioUnidade.Where((ProjetoUsuarioUnidade e) => e.usuarioUID == usuarioUID).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public ResultadoOperacao VincularUnidades(long usuarioUID, long unidadeUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoUsuarioUnidade projetoUsuarioUnidade = contextInstance.ProjetoUsuarioUnidade.Where((ProjetoUsuarioUnidade e) => e.usuarioUID == usuarioUID).FirstOrDefault();
			if (projetoUsuarioUnidade == null)
			{
				projetoUsuarioUnidade = new ProjetoUsuarioUnidade();
				projetoUsuarioUnidade.usuarioUID = usuarioUID;
				projetoUsuarioUnidade.unidadeUID = unidadeUID;
				contextInstance.ProjetoUsuarioUnidade.Add(projetoUsuarioUnidade);
			}
			else
			{
				projetoUsuarioUnidade.unidadeUID = unidadeUID;
				contextInstance.Entry(projetoUsuarioUnidade).State = (EntityState)16;
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Usuário vinculado com sucesso;";
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

	public ResultadoOperacao DesvincularUnidade(long usuarioUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoUsuarioUnidade projetoUsuarioUnidade = contextInstance.ProjetoUsuarioUnidade.Where((ProjetoUsuarioUnidade e) => e.usuarioUID == usuarioUID).FirstOrDefault();
			if (projetoUsuarioUnidade != null)
			{
				contextInstance.ProjetoUsuarioUnidade.Remove(projetoUsuarioUnidade);
				contextInstance.SaveChanges();
			}
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Unidade desvinculada com sucesso;";
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoPreInscricaoDAL
{
	public List<ViewProjetoCursoTurma> ListarInscricoesDisponiveis()
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ViewProjetoCursoTurma
				where e.isTurmaAtiva == true
				orderby e.nomeCurso, e.dataInicioTurma
				select e).ToList();
		}
		catch (Exception)
		{
			return new List<ViewProjetoCursoTurma>();
		}
	}

	public List<ProjetoPreInscricao> ListarInscricoesPorDiscente(long preMatriculaPessoaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoPreInscricao.Where((ProjetoPreInscricao e) => e.preMatriculaPessoaUID == preMatriculaPessoaUID).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoPreInscricao>();
		}
	}

	public ResultadoOperacao PreInscreverDiscente(ProjetoPreInscricao projetoPreInscricao)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			contextInstance.ProjetoPreInscricao.Add(projetoPreInscricao);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Pré-Inscrição realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do Sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ProjetoPreInscricao BuscarInscricaoPorTurmaPessoa(long projetoTurmaUID, long preMatriculaPessoaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoPreInscricao.Where((ProjetoPreInscricao e) => e.projetoTurmaUID == projetoTurmaUID && e.preMatriculaPessoaUID == preMatriculaPessoaUID).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public List<ProjetoPreInscricao> ListarPreInscricoesPorTurma(long projetoTurmaUID, string nome, string cpf, int? situacaoPreInscricao)
	{
		try
		{
			IQueryable<ProjetoPreInscricao> source = Contexto.GetContextInstance().ProjetoPreInscricao.AsQueryable();
			source = source.Where((ProjetoPreInscricao e) => e.projetoTurmaUID == projetoTurmaUID).AsQueryable();
			if (!string.IsNullOrEmpty(nome))
			{
				source = source.Where((ProjetoPreInscricao e) => e.PreMatriculaPessoa.nome.ToUpper().Contains(nome.ToUpper())).AsQueryable();
			}
			if (!string.IsNullOrEmpty(cpf))
			{
				cpf = cpf.Replace(".", "");
				cpf = cpf.Replace("-", "");
				source = source.Where((ProjetoPreInscricao e) => e.PreMatriculaPessoa.cpf == cpf).AsQueryable();
			}
			if (situacaoPreInscricao.HasValue)
			{
				source = source.Where((ProjetoPreInscricao e) => (int?)e.situacaoPreInscricaoEnum == situacaoPreInscricao).AsQueryable();
			}
			return source.OrderBy((ProjetoPreInscricao e) => e.PreMatriculaPessoa.nome).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoPreInscricao>();
		}
	}

	public ResultadoOperacao CancelarPreInscricao(long projetoPreInscricaoUID, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoPreInscricao projetoPreInscricao = contextInstance.ProjetoPreInscricao.Where((ProjetoPreInscricao e) => e.projetoPreInscricaoUID == projetoPreInscricaoUID).FirstOrDefault();
			projetoPreInscricao.situacaoPreInscricaoEnum = 3;
			projetoPreInscricao.dataAtuacao = DateTime.Now;
			projetoPreInscricao.usuarioAtuacaoUID = usuarioUID;
			projetoPreInscricao.ipUsuarioAtuacao = ip;
			contextInstance.Entry(projetoPreInscricao).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Pré-Inscrição cancelada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do Sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ProjetoPreInscricao BuscarPreInscricaoPorUID(long projetoPreInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoPreInscricao.Where((ProjetoPreInscricao e) => e.projetoPreInscricaoUID == projetoPreInscricaoUID).Include((ProjetoPreInscricao e) => e.PreMatriculaPessoa).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}
}

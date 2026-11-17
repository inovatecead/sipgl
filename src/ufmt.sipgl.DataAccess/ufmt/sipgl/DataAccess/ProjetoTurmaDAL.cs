using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTurmaDAL
{
	public ProjetoTurma BuscarTurma(long projetoTurmaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoTurma.Where((ProjetoTurma e) => e.projetoTurmaUID == projetoTurmaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoTurma> ListarTurmaPorCurso(long projetoCursoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ProjetoTurma
				where e.projetoCursoUID == projetoCursoUID
				orderby e.DataInicio
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoTurma> ListarTurmaPorCursoData(long projetoCursoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ProjetoTurma
				where e.projetoCursoUID == projetoCursoUID && e.DataFim >= DateTime.Now
				orderby e.DataInicio
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewProjetoTurmaPolo> ListarPolosPorTurma(long projetoTurmaUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from e in contextInstance.ViewProjetoTurmaPolo
				where e.projetoTurmaUID == projetoTurmaUID
				orderby e.municipio
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoTurmaPolo BuscarTurmaPoloPorId(long? projetoTurmaPoloUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			long uid = projetoTurmaPoloUID.GetValueOrDefault();
			return contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaPoloUID == uid).First();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoTurmaPolo> ListarTurmaPolo(long projetoTurmaUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaUID == projetoTurmaUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Excluir(long projetoTurmaUID, int enderecoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ProjetoTurmaPolo projetoTurmaPolo = contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaUID == projetoTurmaUID && e.enderecoUID == enderecoUID).FirstOrDefault();
			if (Enumerable.Count(projetoTurmaPolo.PreMatriculaInscricao) > 0)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível excluir este registro. Há discentes vinculados a este polo.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
				return resultadoOperacao;
			}
			contextInstance.ProjetoTurmaPolo.Remove(projetoTurmaPolo);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Exclusão efetudada com sucesso.";
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

	public ProjetoTurmaPolo BucarProjetoTurmaPolo(int enderecoUID, long projetoTurmaUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaUID == projetoTurmaUID && e.enderecoUID == enderecoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<EnderecoPoloApoioPresencialEAD> ListarPolosVinculados(long projetoTurmaUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from e in contextInstance.ProjetoTurmaPolo
				where e.projetoTurmaUID == projetoTurmaUID
				select e.EnderecoPoloApoioPresencialEAD).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao VincularPolo(ProjetoTurmaPolo projetoTurmaPolo)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			contextInstance.ProjetoTurmaPolo.Add(projetoTurmaPolo);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Cadastro efetudado com sucesso.";
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

	public ResultadoOperacao AlterarVinculoPolo(int enderecoUID, long projetoTurmaUID, int quantidadeVagas)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ProjetoTurmaPolo projetoTurmaPolo = contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaUID == projetoTurmaUID && e.enderecoUID == enderecoUID).FirstOrDefault();
			projetoTurmaPolo.quantidadeVagas = quantidadeVagas;
			contextInstance.Entry(projetoTurmaPolo).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Alteração efetudada com sucesso.";
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

	public List<ProjetoTurma> FiltrarTurma(long projetoCursoUID, string nome)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			IQueryable<ProjetoTurma> source = contextInstance.ProjetoTurma.AsQueryable();
			source = source.Where((ProjetoTurma e) => e.projetoCursoUID == projetoCursoUID);
			if (!string.IsNullOrWhiteSpace(nome))
			{
				source = source.Where((ProjetoTurma e) => e.nome.ToUpper().Contains(nome.ToUpper()));
			}
			return source.OrderByDescending((ProjetoTurma e) => e.DataFim).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Cadastrar(ProjetoTurma projetoTurma)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			projetoTurma.isAtivo = true;
			contextInstance.ProjetoTurma.Add(projetoTurma);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Cadastro efetudado com sucesso.";
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

	public ResultadoOperacao Alterar(ProjetoTurma novoProjetoTurma)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			ProjetoTurma projetoTurma = contextInstance.ProjetoTurma.Where((ProjetoTurma e) => e.projetoTurmaUID == novoProjetoTurma.projetoTurmaUID).FirstOrDefault();
			projetoTurma.nome = novoProjetoTurma.nome;
			projetoTurma.ano = novoProjetoTurma.ano;
			projetoTurma.periodo = novoProjetoTurma.periodo;
			projetoTurma.turno = novoProjetoTurma.turno;
			projetoTurma.DataInicio = novoProjetoTurma.DataInicio;
			projetoTurma.DataFim = novoProjetoTurma.DataFim;
			projetoTurma.isAtivo = novoProjetoTurma.isAtivo;
			contextInstance.Entry(projetoTurma).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Alteração efetudada com sucesso.";
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

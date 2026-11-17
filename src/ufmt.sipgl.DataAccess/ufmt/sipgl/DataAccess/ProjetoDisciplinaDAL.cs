using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoDisciplinaDAL
{
	public List<ProjetoCorpoDocenteDTO> ListarTodosDocentes()
	{
		try
		{
			return new ProjetoCorpoDocenteDAL().ListarTodos();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoDisciplina BuscarDisciplinaPorId(long projetoDisciplinaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoDisciplinaUID == projetoDisciplinaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ProjetoDisciplina> ListarDisciplinasPorCurso(long projetoCursoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoCursoUID == (long?)projetoCursoUID).Include((ProjetoDisciplina e) => e.ProjetoTurmaDisciplina).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ProjetoDisciplina> ListarDisciplinasPorCursoTurma(long projetoCursoUID, long projetoTurmaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoCursoUID == (long?)projetoCursoUID && e.ProjetoTurmaDisciplina.Any((ProjetoTurmaDisciplina w) => w.projetoTurmaUID == projetoTurmaUID)).Include((ProjetoDisciplina e) => e.ProjetoTurmaDisciplina).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public ResultadoOperacao Excluir(long projetoDisciplinaUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			if (contextInstance.ProjetoTurmaDisciplina.Where((ProjetoTurmaDisciplina e) => e.projetoDisciplinaUID == projetoDisciplinaUID).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível excluir este registro. Esta disciplina já está vinculada a uma turma.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoDisciplina entity = contextInstance.ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoDisciplinaUID == projetoDisciplinaUID).FirstOrDefault();
			contextInstance.ProjetoDisciplina.Remove(entity);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Registro excluído com sucesso.";
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

	public List<ProjetoDisciplina> Filtrar(long projetoCursoUID, string nome)
	{
		try
		{
			IQueryable<ProjetoDisciplina> source = Contexto.GetContextInstance().ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoCursoUID == (long?)projetoCursoUID).AsQueryable();
			if (!string.IsNullOrWhiteSpace(nome))
			{
				source = source.Where((ProjetoDisciplina e) => e.nome.ToUpper().Contains(nome.ToUpper()));
			}
			return source.OrderBy((ProjetoDisciplina e) => e.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao CadastrarDisciplina(ProjetoDisciplina projetoDisciplina)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			int tipoDisciplina = 2;
			if (projetoDisciplina.tipoDisciplina.GetValueOrDefault() == tipoDisciplina && contextInstance.ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoCursoUID == projetoDisciplina.projetoCursoUID && e.tipoDisciplina == (int?)tipoDisciplina).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe uma disciplina do tipo TCC cadastrada para este curso";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (string.IsNullOrWhiteSpace(projetoDisciplina.ementa) || string.IsNullOrWhiteSpace(projetoDisciplina.bibliografia))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Ementa e Bibliografia são obrigatórios";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			contextInstance.ProjetoDisciplina.Add(projetoDisciplina);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Cadastro efetudado com sucesso.";
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

	public ResultadoOperacao AlterarDisciplina(ProjetoDisciplina projetoDisciplinaNova)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoDisciplina projetoDisciplina = contextInstance.ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoDisciplinaUID == projetoDisciplinaNova.projetoDisciplinaUID).FirstOrDefault();
			int tipoDisciplina = 2;
			if (projetoDisciplinaNova.tipoDisciplina.GetValueOrDefault() == tipoDisciplina)
			{
				ProjetoDisciplina projetoDisciplina2 = contextInstance.ProjetoDisciplina.Where((ProjetoDisciplina e) => e.projetoCursoUID == projetoDisciplina.projetoCursoUID && e.tipoDisciplina == (int?)tipoDisciplina).FirstOrDefault();
				if (projetoDisciplina2 != null && projetoDisciplina2.projetoDisciplinaUID != projetoDisciplina.projetoDisciplinaUID)
				{
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "Já existe uma disciplina do tipo TCC cadastrada para este curso";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					return resultadoOperacao;
				}
			}
			if (string.IsNullOrWhiteSpace(projetoDisciplinaNova.ementa) || string.IsNullOrWhiteSpace(projetoDisciplinaNova.bibliografia))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Ementa e Bibliografia são obrigatórios";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			projetoDisciplina.bibliografia = projetoDisciplinaNova.bibliografia;
			projetoDisciplina.cargaHoraria = projetoDisciplinaNova.cargaHoraria;
			projetoDisciplina.ementa = projetoDisciplinaNova.ementa;
			projetoDisciplina.nome = projetoDisciplinaNova.nome;
			projetoDisciplina.tipoDisciplina = projetoDisciplinaNova.tipoDisciplina;
			contextInstance.Entry(projetoDisciplina).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Alteração efetudada com sucesso.";
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
}

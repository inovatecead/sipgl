using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoEncontroPresencialDAL
{
	public List<ViewProjetoEncontroPresencial> FiltrarEncontroPresencialPorDisciplinaTurmaPolo(long projetoDisciplinaUID, long? projetoTurmaUID, int? enderecoUID)
	{
		try
		{
			IQueryable<ViewProjetoEncontroPresencial> source = Contexto.GetContextInstance().ViewProjetoEncontroPresencial.AsQueryable();
			source = source.Where((ViewProjetoEncontroPresencial e) => e.projetoDisciplinaUID == projetoDisciplinaUID);
			if (projetoTurmaUID.HasValue)
			{
				source = source.Where((ViewProjetoEncontroPresencial e) => (long?)e.projetoTurmaUID == projetoTurmaUID);
			}
			if (enderecoUID.HasValue)
			{
				source = source.Where((ViewProjetoEncontroPresencial e) => (int?)e.enderecoUID == enderecoUID);
			}
			return (from e in source
				orderby e.dataEncontro, e.identificacaoEndereco, e.nomeTurma
				select e).ToList();
		}
		catch (Exception)
		{
			return new List<ViewProjetoEncontroPresencial>();
		}
	}

	public List<ViewProjetoEncontroPresencial> ListarEncontroPresencialPorDisciplina(long projetoDisciplinaUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ViewProjetoEncontroPresencial
				where e.projetoDisciplinaUID == projetoDisciplinaUID
				orderby e.dataEncontro, e.identificacaoEndereco, e.nomeTurma
				select e).ToList();
		}
		catch (Exception)
		{
			return new List<ViewProjetoEncontroPresencial>();
		}
	}

	public ResultadoOperacao Excluir(long projetoEncontroPresencialUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			if (contextInstance.ProjetoFrequencia.Where((ProjetoFrequencia e) => e.projetoEncontroPresencialUID == projetoEncontroPresencialUID).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não é possível excluir este registro pois há lançamento de frequências vinculados.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoEncontroPresencial entity = contextInstance.ProjetoEncontroPresencial.Where((ProjetoEncontroPresencial e) => e.projetoEncontroPresencialUID == projetoEncontroPresencialUID).FirstOrDefault();
			contextInstance.ProjetoEncontroPresencial.Remove(entity);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Encontro Presencial excluído com sucesso.";
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

	public ProjetoEncontroPresencial BuscarEncontroPresencialPorId(long projetoEncontroPresencialUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoEncontroPresencial.Where((ProjetoEncontroPresencial e) => e.projetoEncontroPresencialUID == projetoEncontroPresencialUID).Include((ProjetoEncontroPresencial e) => e.ProjetoTurmaPolo).FirstOrDefault();
		}
		catch (Exception)
		{
			return new ProjetoEncontroPresencial();
		}
	}

	public ProjetoEncontroPresencial BuscarEncontroPresencialPorDisciplinaData(long projetoDisciplinaUID, DateTime dataEncontro)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoEncontroPresencial.Where((ProjetoEncontroPresencial e) => e.projetoDisciplinaUID == projetoDisciplinaUID && e.dataEncontro == dataEncontro).FirstOrDefault();
		}
		catch (Exception)
		{
			return new ProjetoEncontroPresencial();
		}
	}

	public ResultadoOperacao CadastrarEncontroPresencial(ProjetoEncontroPresencial projetoEncontroPresencial, long projetoTurmaUID, int enderecoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			if (contextInstance.ProjetoEncontroPresencial.Where((ProjetoEncontroPresencial e) => e.projetoDisciplinaUID == projetoEncontroPresencial.projetoDisciplinaUID && e.ProjetoTurmaPolo.enderecoUID == enderecoUID && e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID && e.dataEncontro == projetoEncontroPresencial.dataEncontro).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe um encontro presencial cadastrado para esta data.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
				return resultadoOperacao;
			}
			ProjetoTurmaPolo projetoTurmaPolo = contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaUID == projetoTurmaUID && e.enderecoUID == enderecoUID).FirstOrDefault();
			projetoEncontroPresencial.projetoTurmaPoloUID = projetoTurmaPolo.projetoTurmaPoloUID;
			contextInstance.ProjetoEncontroPresencial.Add(projetoEncontroPresencial);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Encontro Presencial cadastrado com sucesso.";
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

	public ResultadoOperacao AlterarEncontroPresencial(ProjetoEncontroPresencial novoProjetoEncontroPresencial, long projetoTurmaUID, int enderecoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoEncontroPresencial projetoEncontroPresencial = contextInstance.ProjetoEncontroPresencial.Where((ProjetoEncontroPresencial e) => e.projetoDisciplinaUID == novoProjetoEncontroPresencial.projetoDisciplinaUID && e.ProjetoTurmaPolo.enderecoUID == enderecoUID && e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID && e.dataEncontro == novoProjetoEncontroPresencial.dataEncontro).FirstOrDefault();
			if (projetoEncontroPresencial != null && projetoEncontroPresencial.projetoEncontroPresencialUID != novoProjetoEncontroPresencial.projetoEncontroPresencialUID)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe um encontro presencial para esta data.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
				return resultadoOperacao;
			}
			ProjetoEncontroPresencial projetoEncontroPresencial2 = contextInstance.ProjetoEncontroPresencial.Where((ProjetoEncontroPresencial e) => e.projetoEncontroPresencialUID == novoProjetoEncontroPresencial.projetoEncontroPresencialUID).FirstOrDefault();
			ProjetoTurmaPolo projetoTurmaPolo = contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaUID == projetoTurmaUID && e.enderecoUID == enderecoUID).FirstOrDefault();
			projetoEncontroPresencial2.projetoTurmaPoloUID = projetoTurmaPolo.projetoTurmaPoloUID;
			projetoEncontroPresencial2.dataEncontro = novoProjetoEncontroPresencial.dataEncontro;
			projetoEncontroPresencial2.isObrigatorio = novoProjetoEncontroPresencial.isObrigatorio;
			contextInstance.Entry(projetoEncontroPresencial2).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Encontro Presencial alterado com sucesso.";
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

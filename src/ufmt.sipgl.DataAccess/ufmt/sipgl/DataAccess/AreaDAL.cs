using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class AreaDAL
{
	public List<CNPqAreaConhecimento> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqAreaConhecimento.Select((CNPqAreaConhecimento c) => c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CNPqAreaConhecimento> GetRegistros(long idSuperior)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqAreaConhecimento.Where((CNPqAreaConhecimento c) => c.CNPqGrandeAreaConhecimentoUID == idSuperior).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public DetalheAreaConhecimento getDetalhesAreaConhecimento(long projetoCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		return (from ga in contextInstance.CNPqGrandeAreaConhecimento
			join a in contextInstance.CNPqAreaConhecimento on ga.CNPqGrandeAreaConhecimentoUID equals a.CNPqGrandeAreaConhecimentoUID
			join p in contextInstance.ProjetoCurso on a.CNPqAreaConhecimentoUID equals p.CNPqAreaConhecimentoUID
			join sa in contextInstance.CNPqSubAreaConhecimento on a.CNPqAreaConhecimentoUID equals sa.CNPqAreaConhecimentoUID
			where p.projetoCursoUID == projetoCursoUID
			select new DetalheAreaConhecimento
			{
				DescricaoGrandeAreaConhecimento = ga.nome,
				DescricaoAreaConhecimento = a.nome,
				DescricaoSubAreaConhecimento = sa.nome,
				CNPqGrandeAreaConhecimentoUID = ga.CNPqGrandeAreaConhecimentoUID,
				CNPqAreaConhecimentoUID = a.CNPqAreaConhecimentoUID,
				CNPqSubAreaConhecimentoUID = sa.CNPqSubAreaConhecimentoUID
			}).FirstOrDefault();
	}

	public List<CNPqSubAreaConhecimento> GetRegistrosSubArea(long idSuperior)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqSubAreaConhecimento.Where((CNPqSubAreaConhecimento c) => c.CNPqAreaConhecimentoUID == idSuperior).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public CNPqAreaConhecimento GetPorId(int id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqAreaConhecimento.Where((CNPqAreaConhecimento c) => c.CNPqAreaConhecimentoUID == (long)id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<Especialidade> GetArea()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.Especialidade
				where c.excluida == false
				orderby c.nome
				select c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<Especialidade> GetEspecialidadeEstruturaCurricular(long estruturaCurricularUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.Especialidade
				where c.estruturaCurricularUID == estruturaCurricularUID && c.excluida == false
				orderby c.nome
				select c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CNPqAreaConhecimento> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CNPqAreaConhecimento.Where((CNPqAreaConhecimento c) => c.nome.Contains(criterio)).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Salvar(Especialidade area)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		long? especialidadeUID = null;
		if (area.especialidadeUID != 0L)
		{
			especialidadeUID = area.especialidadeUID;
		}
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			ObjectParameter val = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureInserirEditarEspecialidade(especialidadeUID, area.estruturaCurricularUID, area.nome, val);
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.Erro = false;
				resultadoOperacao.TextMessage = "Especialidade cadastrada com sucesso.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível salvar o registro. " + array[1];
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao Excluir(long id)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			ObjectParameter val = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureExcluirEspecialidade(id, val);
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.Erro = false;
				resultadoOperacao.TextMessage = "Especialidade excluída com sucesso.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível excluir o registro. " + array[1];
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
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

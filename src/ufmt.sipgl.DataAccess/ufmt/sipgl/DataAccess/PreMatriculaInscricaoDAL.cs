using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class PreMatriculaInscricaoDAL
{
	public PreMatriculaInscricao BuscarPreMatriculaInscricaoPorUID(long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a inscrição do discente", innerException);
		}
	}

	public List<ViewPreMatriculaInscricaoOcorrencia> ListarViewHistoricoAlteracao(long preMatriculaInscricaoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ViewPreMatriculaInscricaoOcorrencia
				where e.preMatriculaInscricaoUID == preMatriculaInscricaoUID
				orderby e.dataHoraOcorrencia descending
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a inscrição do discente", innerException);
		}
	}

	public List<ViewPreMatriculaInscricaoTurma> FiltrarInscricoes(long projetoTurmaUID, int enderecoUID, long tipoSituacaoInscricaoUID)
	{
		try
		{
			IQueryable<ViewPreMatriculaInscricaoTurma> source = Contexto.GetContextInstance().ViewPreMatriculaInscricaoTurma.AsQueryable();
			if (projetoTurmaUID > 0)
			{
				source = source.Where((ViewPreMatriculaInscricaoTurma e) => e.projetoTurmaUID == projetoTurmaUID);
			}
			if (enderecoUID > 0)
			{
				source = source.Where((ViewPreMatriculaInscricaoTurma e) => e.enderecoUID == enderecoUID);
			}
			if (tipoSituacaoInscricaoUID > 0)
			{
				source = source.Where((ViewPreMatriculaInscricaoTurma e) => (long)e.tipoSituacaoInscricaoUID == tipoSituacaoInscricaoUID);
			}
			return (from e in source
				orderby e.identificacaoEndereco, e.nome
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a inscrição do discente", innerException);
		}
	}

	public ResultadoOperacao ExcluirDiscenteTurma(int preMatriculaInscricaoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaInscricao entity = contextInstance.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.preMatriculaInscricaoUID == (long)preMatriculaInscricaoUID).Include((PreMatriculaInscricao e) => e.PreMatriculaInscricaoOcorrencia).Include((PreMatriculaInscricao e) => e.ProjetoNota)
				.Include((PreMatriculaInscricao e) => e.ProjetoFrequencia)
				.FirstOrDefault();
			List<PreMatriculaInscricaoOcorrencia> list = contextInstance.PreMatriculaInscricaoOcorrencia.Where((PreMatriculaInscricaoOcorrencia e) => e.preMatriculaInscricaoUID == (long)preMatriculaInscricaoUID).ToList();
			if (list != null)
			{
				foreach (PreMatriculaInscricaoOcorrencia item in list)
				{
					PreMatriculaInscricaoOcorrencia entity2 = contextInstance.PreMatriculaInscricaoOcorrencia.Where((PreMatriculaInscricaoOcorrencia e) => e.preMatriculaIncricaoOcorrenciaUID == item.preMatriculaIncricaoOcorrenciaUID).FirstOrDefault();
					contextInstance.PreMatriculaInscricaoOcorrencia.Remove(entity2);
				}
			}
			List<ProjetoNota> list2 = contextInstance.ProjetoNota.Where((ProjetoNota e) => e.preMatriculaInscricaoUID == (long)preMatriculaInscricaoUID).ToList();
			if (list2 != null)
			{
				foreach (ProjetoNota item2 in list2)
				{
					ProjetoNota entity3 = contextInstance.ProjetoNota.Where((ProjetoNota e) => e.projetoNotaUID == item2.projetoNotaUID).FirstOrDefault();
					contextInstance.ProjetoNota.Remove(entity3);
				}
			}
			List<ProjetoFrequencia> list3 = contextInstance.ProjetoFrequencia.Where((ProjetoFrequencia e) => e.preMatriculaInscricaoUID == (long)preMatriculaInscricaoUID).ToList();
			if (list3 != null)
			{
				foreach (ProjetoFrequencia item3 in list3)
				{
					ProjetoFrequencia entity4 = contextInstance.ProjetoFrequencia.Where((ProjetoFrequencia e) => e.projetoFrequenciaUID == item3.projetoFrequenciaUID).FirstOrDefault();
					contextInstance.ProjetoFrequencia.Remove(entity4);
				}
			}
			ProjetoDiscente projetoDiscente = contextInstance.ProjetoDiscente.Where((ProjetoDiscente e) => e.preMatriculaInscricaoUID == (long)preMatriculaInscricaoUID).FirstOrDefault();
			if (projetoDiscente != null)
			{
				contextInstance.ProjetoDiscente.Remove(projetoDiscente);
			}
			contextInstance.PreMatriculaInscricao.Remove(entity);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Discente Excluído com sucesso.";
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

	public List<ViewPreMatriculaInscricaoTurma> ListarViewPreMatriculaInscricaoTurma(long enderecoUID, long projetoTurmaUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ViewPreMatriculaInscricaoTurma.AsQueryable()
				where e.projetoTurmaUID == projetoTurmaUID && (long)e.enderecoUID == enderecoUID
				where (uint)e.tipoSituacaoInscricaoUID > 2u
				orderby e.nome
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a inscrição do discente", innerException);
		}
	}

	public List<ViewPreMatriculaInscricao> ListarMatriculasPorPessoa(long preMatriculaPessoaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ViewPreMatriculaInscricao.Where((ViewPreMatriculaInscricao e) => e.preMatriculaPessoaUID == preMatriculaPessoaUID).ToList();
		}
		catch (Exception)
		{
			return new List<ViewPreMatriculaInscricao>();
		}
	}

	public bool HasVagasDisponiveis(long projetoTurmaPoloUID)
	{
		try
		{
			ProjetoTurmaPolo? projetoTurmaPolo = Contexto.GetContextInstance().ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.projetoTurmaPoloUID == projetoTurmaPoloUID).FirstOrDefault();
			int num = projetoTurmaPolo.PreMatriculaInscricao.Where((PreMatriculaInscricao y) => y.tipoSituacaoInscricaoUID == 3 || y.tipoSituacaoInscricaoUID == 7).Count();
			return projetoTurmaPolo.quantidadeVagas - num > 0;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public ResultadoOperacao InscreverCandidato(PreMatriculaInscricao preMatriculaInscricao, PreMatriculaInscricaoOcorrencia preMatriculaInscricaoOcorrencia, ProjetoDiscente projetoDiscente)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ObjectParameter val = new ObjectParameter("numeroInscricaoSaida", typeof(int));
			contextInstance.ProcedureGerarNumeroPreMatriculaInscricao(val);
			preMatriculaInscricao.numeroInscricao = (int)val.Value;
			projetoDiscente.registro = GerarNumeroRegistroAluno(preMatriculaInscricao.projetoTurmaPoloUID.GetValueOrDefault());
			ProjetoTurmaPolo projetoTurmaPolo = contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => (long?)e.projetoTurmaPoloUID == preMatriculaInscricao.projetoTurmaPoloUID).FirstOrDefault();
			ProjetoPreInscricao projetoPreInscricao = contextInstance.ProjetoPreInscricao.Where((ProjetoPreInscricao e) => e.projetoTurmaUID == projetoTurmaPolo.projetoTurmaUID && e.preMatriculaPessoaUID == preMatriculaInscricao.preMatriculaPessoaUID).FirstOrDefault();
			if (projetoPreInscricao == null)
			{
				projetoPreInscricao = new ProjetoPreInscricao();
				projetoPreInscricao.preMatriculaInscricaoUID = preMatriculaInscricao.preMatriculaInscricaoUID;
				projetoPreInscricao.projetoTurmaUID = projetoTurmaPolo.projetoTurmaUID;
				projetoPreInscricao.preMatriculaPessoaUID = preMatriculaInscricao.preMatriculaPessoaUID;
				projetoPreInscricao.situacaoPreInscricaoEnum = 2;
				projetoPreInscricao.dataSolicitacao = DateTime.Now;
				projetoPreInscricao.dataAtuacao = DateTime.Now;
				projetoPreInscricao.usuarioAtuacaoUID = preMatriculaInscricaoOcorrencia.usuarioUID;
				projetoPreInscricao.ipUsuarioAtuacao = preMatriculaInscricaoOcorrencia.ip;
				contextInstance.ProjetoPreInscricao.Add(projetoPreInscricao);
			}
			else
			{
				projetoPreInscricao.preMatriculaInscricaoUID = preMatriculaInscricao.preMatriculaInscricaoUID;
				projetoPreInscricao.situacaoPreInscricaoEnum = 2;
				projetoPreInscricao.dataAtuacao = DateTime.Now;
				projetoPreInscricao.usuarioAtuacaoUID = preMatriculaInscricaoOcorrencia.usuarioUID;
				projetoPreInscricao.ipUsuarioAtuacao = preMatriculaInscricaoOcorrencia.ip;
				contextInstance.Entry(projetoPreInscricao).State = (EntityState)16;
			}
			contextInstance.PreMatriculaInscricao.Add(preMatriculaInscricao);
			contextInstance.PreMatriculaInscricaoOcorrencia.Add(preMatriculaInscricaoOcorrencia);
			contextInstance.ProjetoDiscente.Add(projetoDiscente);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Inscrição de candidato realizada com sucesso.";
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

	public string GerarNumeroRegistroAluno(long projetoTurmaPoloUID)
	{
		int num = Contexto.GetContextInstance().ProjetoDiscente.Where((ProjetoDiscente e) => e.PreMatriculaInscricao.projetoTurmaPoloUID == (long?)projetoTurmaPoloUID).Count();
		return DateTime.Now.Year.ToString() + projetoTurmaPoloUID + (num + 1).ToString("#0000");
	}

	public bool IsDiscente(long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoDiscente.Where((ProjetoDiscente e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).Any();
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool BuscarPreMatriculaInscricao(long preMatriculaPessoaUID, long projetoTurmaUID)
	{
		try
		{
			return Contexto.GetContextInstance().PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.preMatriculaPessoaUID == preMatriculaPessoaUID && e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID).Any();
		}
		catch (Exception)
		{
			return true;
		}
	}
}

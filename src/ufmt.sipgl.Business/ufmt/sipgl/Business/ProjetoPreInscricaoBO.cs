using System;
using System.Collections.Generic;
using System.Linq;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.Business;

public class ProjetoPreInscricaoBO
{
	public ProjetoPreInscricaoDAL ProjetoPreInscricaoDAL { get; set; }

	public ProjetoPreInscricaoBO()
	{
		ProjetoPreInscricaoDAL = new ProjetoPreInscricaoDAL();
	}

	public List<PreInscricaoDTO> ListarInscricoesDisponiveis(long preMatriculaPessoaUID)
	{
		List<ViewProjetoCursoTurma> list = ProjetoPreInscricaoDAL.ListarInscricoesDisponiveis();
		List<ProjetoPreInscricao> source = ProjetoPreInscricaoDAL.ListarInscricoesPorDiscente(preMatriculaPessoaUID);
		List<PreInscricaoDTO> list2 = new List<PreInscricaoDTO>();
		if (list == null)
		{
			return list2;
		}
		foreach (ViewProjetoCursoTurma item in list)
		{
			PreInscricaoDTO preInscricaoDTO = new PreInscricaoDTO();
			preInscricaoDTO.ProjetoCursoUID = item.projetoCursoUID;
			preInscricaoDTO.NomeCurso = item.nomeCurso;
			preInscricaoDTO.ProjetoTurmaUID = item.projetoTurmaUID;
			preInscricaoDTO.DescricaoTurma = item.descricaoTurma;
			preInscricaoDTO.DataInicioTurma = item.dataInicioTurma;
			preInscricaoDTO.DataFimTurma = item.dataFimTurma;
			ProjetoPreInscricao projetoPreInscricao = source.Where((ProjetoPreInscricao e) => e.projetoTurmaUID == item.projetoTurmaUID).FirstOrDefault();
			if (projetoPreInscricao != null)
			{
				preInscricaoDTO.DataAtuacao = projetoPreInscricao.dataAtuacao;
				preInscricaoDTO.DataSolicitacao = projetoPreInscricao.dataSolicitacao;
				preInscricaoDTO.EnumSituacaoPreInscricao = (EnumSituacaoPreInscricao)projetoPreInscricao.situacaoPreInscricaoEnum;
				preInscricaoDTO.DescricaoSituacaoEnum = preInscricaoDTO.EnumSituacaoPreInscricao.ToString();
				preInscricaoDTO.PreMatriculaInscricaoUID = projetoPreInscricao.preMatriculaInscricaoUID;
				preInscricaoDTO.PreMatriculaPessoaUID = projetoPreInscricao.preMatriculaPessoaUID;
			}
			list2.Add(preInscricaoDTO);
		}
		return list2;
	}

	public List<ProjetoPreInscricao> ListarPreInscricoesPorTurma(long projetoTurmaUID, string nome, string cpf, int? situacaoPreInscricao)
	{
		return ProjetoPreInscricaoDAL.ListarPreInscricoesPorTurma(projetoTurmaUID, nome, cpf, situacaoPreInscricao);
	}

	public ResultadoOperacao PreInscreverDiscente(long preMatriculaPessoaUID, long projetoTurmaUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (!ValidarPreInscricao(preMatriculaPessoaUID, projetoTurmaUID))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe uma solicitação de pré-inscrição para esta turma. Aguarde a resposta do coordenador.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoPreInscricao projetoPreInscricao = new ProjetoPreInscricao();
			projetoPreInscricao.preMatriculaPessoaUID = preMatriculaPessoaUID;
			projetoPreInscricao.projetoTurmaUID = projetoTurmaUID;
			projetoPreInscricao.situacaoPreInscricaoEnum = 1;
			projetoPreInscricao.dataSolicitacao = DateTime.Now;
			resultadoOperacao = ProjetoPreInscricaoDAL.PreInscreverDiscente(projetoPreInscricao);
			return resultadoOperacao;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do Sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			return resultadoOperacao;
		}
	}

	public bool ValidarPreInscricao(long preMatriculaPessoaUID, long projetoTurmaUID)
	{
		if (BuscarInscricaoPorTurmaPessoa(projetoTurmaUID, preMatriculaPessoaUID) != null)
		{
			return false;
		}
		return true;
	}

	public ProjetoPreInscricao BuscarInscricaoPorTurmaPessoa(long projetoTurmaUID, long preMatriculaPessoaUID)
	{
		return ProjetoPreInscricaoDAL.BuscarInscricaoPorTurmaPessoa(projetoTurmaUID, preMatriculaPessoaUID);
	}

	public ResultadoOperacao CancelarPreInscricao(long projetoPreInscricaoUID, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (ValidarPreInscricaoPorSituacao(projetoPreInscricaoUID, EnumSituacaoPreInscricao.CANCELADO))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Pré-Inscrição já se encontra cancelada.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			resultadoOperacao = ProjetoPreInscricaoDAL.CancelarPreInscricao(projetoPreInscricaoUID, usuarioUID, ip);
			return resultadoOperacao;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do Sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			return resultadoOperacao;
		}
	}

	public bool ValidarPreInscricaoPorSituacao(long projetoPreInscricaoUID, EnumSituacaoPreInscricao enumSituacaoPreInscricao)
	{
		if (ProjetoPreInscricaoDAL.BuscarPreInscricaoPorUID(projetoPreInscricaoUID).situacaoPreInscricaoEnum == (int)enumSituacaoPreInscricao)
		{
			return true;
		}
		return false;
	}

	public ProjetoPreInscricao BuscarPreInscricaoPorUID(long projetoPreInscricaoUID)
	{
		return ProjetoPreInscricaoDAL.BuscarPreInscricaoPorUID(projetoPreInscricaoUID);
	}
}

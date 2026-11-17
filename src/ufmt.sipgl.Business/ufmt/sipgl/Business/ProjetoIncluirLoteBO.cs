using System;
using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoIncluirLoteBO
{
	public List<string> IncluirLote(List<string> listaAlunos, long projetoTurmaUID, long usuarioUID, string ip)
	{
		DiscenteBO discenteBO = new DiscenteBO();
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		EnderecoPoloPresencialEadBO enderecoPoloPresencialEadBO = new EnderecoPoloPresencialEadBO();
		TipoSituacaoInscricaoBO tipoSituacaoInscricaoBO = new TipoSituacaoInscricaoBO();
		TipoReservaVagaBO tipoReservaVagaBO = new TipoReservaVagaBO();
		TipoFormaIngressoBO tipoFormaIngressoBO = new TipoFormaIngressoBO();
		TipoPeriodoIngressoBO tipoPeriodoIngressoBO = new TipoPeriodoIngressoBO();
		List<string> list = new List<string>();
		foreach (string listaAluno in listaAlunos)
		{
			string[] array = listaAluno.Split(new char[1] { ';' });
			ViewEnderecoPoloEAD viewEnderecoPoloEAD = enderecoPoloPresencialEadBO.BuscarPorIdentificacao(array[0].Trim());
			if (viewEnderecoPoloEAD == null)
			{
				list.Add($"CPF: {array[1]} - O polo informado não foi encontrado.");
				continue;
			}
			ProjetoTurmaPolo projetoTurmaPolo = projetoTurmaBO.BucarProjetoTurmaPolo(viewEnderecoPoloEAD.enderecoUID, projetoTurmaUID);
			if (projetoTurmaPolo == null)
			{
				list.Add($"CPF: {array[1]} - O polo informado não está vinculado a esta turma ({array[0]}).");
				continue;
			}
			PreMatriculaPessoa preMatriculaPessoa = preMatriculaPessoaBO.BuscarPreMatriculaPessoaPorCPF(array[1].Trim());
			if (preMatriculaPessoa == null)
			{
				list.Add($"CPF: {array[1]} - CPF não encontrado na base de dados.");
				continue;
			}
			if (preMatriculaInscricaoBO.IsInscrito(preMatriculaPessoa.preMatriculaPessoaUID, projetoTurmaUID))
			{
				list.Add($"CPF: {array[1]} - Aluno já adicionado a esta turma.");
				continue;
			}
			TipoSituacaoInscricao tipoSituacaoInscricao = tipoSituacaoInscricaoBO.BuscarTipoSituacaoInscricaoPorDescricao(array[2]);
			if (tipoSituacaoInscricao == null)
			{
				list.Add($"CPF: {array[1]} - Situação de Inscrição não localizada.");
				continue;
			}
			if ((tipoSituacaoInscricao.tipoSituacaoInscricaoUID == 3 || tipoSituacaoInscricao.tipoSituacaoInscricaoUID == 7) && !preMatriculaInscricaoBO.HasVagasDisponiveis(projetoTurmaPolo.projetoTurmaPoloUID))
			{
				list.Add($"CPF: {array[1]} - Não há mais vagas disponíveis para o Polo selecionado");
				continue;
			}
			TipoFormaIngresso tipoFormaIngresso = tipoFormaIngressoBO.BuscarPorNome(array[3]);
			if (tipoFormaIngresso == null)
			{
				list.Add($"CPF: {array[1]} - Forma de Ingresso não localizada.");
				continue;
			}
			TipoPeriodoIngresso tipoPeriodoIngresso = tipoPeriodoIngressoBO.BuscarPorNome(array[4]);
			if (tipoPeriodoIngresso == null)
			{
				list.Add($"CPF: {array[1]} - Periodo de Ingresso não localizada.");
				continue;
			}
			TipoReservaVagas tipoReservaVagas = tipoReservaVagaBO.BuscarPorNome(array[5]);
			if (tipoReservaVagas == null)
			{
				list.Add($"CPF: {array[1]} - Tipo de vaga não localizada.");
				continue;
			}
			PreMatriculaInscricao preMatriculaInscricao = new PreMatriculaInscricao();
			preMatriculaInscricao.preMatriculaPessoaUID = preMatriculaPessoa.preMatriculaPessoaUID;
			preMatriculaInscricao.projetoTurmaPoloUID = projetoTurmaPolo.projetoTurmaPoloUID;
			preMatriculaInscricao.tipoSituacaoInscricaoUID = tipoSituacaoInscricao.tipoSituacaoInscricaoUID;
			ProjetoDiscente projetoDiscente = new ProjetoDiscente();
			projetoDiscente.tipoFormaIngressoUID = tipoFormaIngresso.tipoFormaIngressoUID;
			projetoDiscente.tipoPeridoIngressoUID = tipoPeriodoIngresso.tipoPeriodoIngressoUID;
			projetoDiscente.tipoReservaVagasUID = tipoReservaVagas.tipoReservaVagasUID;
			projetoDiscente.dataIngresso = Convert.ToDateTime(array[6].Trim());
			projetoDiscente.periodo = int.Parse(array[7].Trim());
			string observacao = ((array[8].Length >= 2048) ? array[8].Substring(0, 2048) : array[8]);
			if (discenteBO.InscreverCandidato(preMatriculaInscricao, projetoDiscente, observacao, usuarioUID, ip).Erro)
			{
				list.Add($"CPF: {array[1]} - Erro ao incluir.");
			}
		}
		return list;
	}
}

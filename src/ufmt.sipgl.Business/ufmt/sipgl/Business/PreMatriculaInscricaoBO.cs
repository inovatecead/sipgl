using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class PreMatriculaInscricaoBO
{
	public PreMatriculaInscricaoDAL PreMatriculaInscricaoDAL { get; set; }

	public PreMatriculaInscricaoBO()
	{
		PreMatriculaInscricaoDAL = new PreMatriculaInscricaoDAL();
	}

	public List<ViewPreMatriculaInscricaoTurma> FiltrarInscricoes(long projetoTurmaUID, int enderecoUID, long tipoSituacaoInscricaoUID)
	{
		return PreMatriculaInscricaoDAL.FiltrarInscricoes(projetoTurmaUID, enderecoUID, tipoSituacaoInscricaoUID);
	}

	public bool IsInscrito(long preMatriculaPessoaUID, long projetoTurmaUID)
	{
		return PreMatriculaInscricaoDAL.BuscarPreMatriculaInscricao(preMatriculaPessoaUID, projetoTurmaUID);
	}

	public bool HasVagasDisponiveis(long projetoTurmaPoloUID)
	{
		return PreMatriculaInscricaoDAL.HasVagasDisponiveis(projetoTurmaPoloUID);
	}

	public List<ViewPreMatriculaInscricaoOcorrencia> ListarViewHistoricoAlteracao(long preMatriculaInscricaoUID)
	{
		return PreMatriculaInscricaoDAL.ListarViewHistoricoAlteracao(preMatriculaInscricaoUID);
	}

	public PreMatriculaInscricao BuscarPreMatriculaInscricaoPorUID(long preMatriculaInscricaoUID)
	{
		return PreMatriculaInscricaoDAL.BuscarPreMatriculaInscricaoPorUID(preMatriculaInscricaoUID);
	}

	public List<ViewPreMatriculaInscricao> ListarMatriculasPorPessoa(long preMatriculaPessoaUID)
	{
		return PreMatriculaInscricaoDAL.ListarMatriculasPorPessoa(preMatriculaPessoaUID);
	}

	public List<ViewPreMatriculaInscricaoTurma> ListarViewPreMatriculaInscricaoTurma(long enderecoUID, long projetoTurmaUID)
	{
		return PreMatriculaInscricaoDAL.ListarViewPreMatriculaInscricaoTurma(enderecoUID, projetoTurmaUID);
	}

	public ResultadoOperacao ExcluirDiscenteTurma(int preMatriculaInscricaoUID)
	{
		return PreMatriculaInscricaoDAL.ExcluirDiscenteTurma(preMatriculaInscricaoUID);
	}
}

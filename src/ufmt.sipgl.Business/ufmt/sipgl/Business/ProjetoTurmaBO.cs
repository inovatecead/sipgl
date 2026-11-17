using System.Collections.Generic;
using System.Linq;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.Business;

public class ProjetoTurmaBO
{
	private ProjetoTurmaDAL projetoTurmaDAL;

	public ProjetoTurmaBO()
	{
		projetoTurmaDAL = new ProjetoTurmaDAL();
	}

	public List<ProjetoTurma> FiltrarTurma(long projetoCursoUID, string nome)
	{
		return projetoTurmaDAL.FiltrarTurma(projetoCursoUID, nome);
	}

	public ProjetoTurma BuscarTurma(long projetoTurmaUID)
	{
		return projetoTurmaDAL.BuscarTurma(projetoTurmaUID);
	}

	public List<ViewProjetoTurmaPolo> ListarPolosPorTurma(long projetoTurmaUID)
	{
		return projetoTurmaDAL.ListarPolosPorTurma(projetoTurmaUID);
	}

	public List<ProjetoTurma> ListarTurmaPorCurso(long projetoCursoUID)
	{
		return projetoTurmaDAL.ListarTurmaPorCurso(projetoCursoUID);
	}

	public List<ProjetoTurma> ListarTurmaPorCursoData(long projetoCursoUID)
	{
		return projetoTurmaDAL.ListarTurmaPorCursoData(projetoCursoUID);
	}

	public ResultadoOperacao VincularPolo(int enderecoUID, long projetoTurmaUID, int quantidadeVagas)
	{
		ResultadoOperacao resultadoOperacao = ValidarPoloDuplicado(enderecoUID, projetoTurmaUID);
		if (resultadoOperacao.Erro)
		{
			return resultadoOperacao;
		}
		ProjetoTurmaPolo projetoTurmaPolo = new ProjetoTurmaPolo();
		projetoTurmaPolo.enderecoUID = enderecoUID;
		projetoTurmaPolo.projetoTurmaUID = projetoTurmaUID;
		projetoTurmaPolo.quantidadeVagas = quantidadeVagas;
		return projetoTurmaDAL.VincularPolo(projetoTurmaPolo);
	}

	public ResultadoOperacao AlterarVinculoPolo(int enderecoUID, long projetoTurmaUID, int quantidadeVagas)
	{
		return projetoTurmaDAL.AlterarVinculoPolo(enderecoUID, projetoTurmaUID, quantidadeVagas);
	}

	public ProjetoTurmaPolo BuscarTurmaPoloPorId(long? projetoPoloTurmaUID)
	{
		return projetoTurmaDAL.BuscarTurmaPoloPorId(projetoPoloTurmaUID);
	}

	public ResultadoOperacao Excluir(long projetoTurmaUID, int enderecoUID)
	{
		return projetoTurmaDAL.Excluir(projetoTurmaUID, enderecoUID);
	}

	public ResultadoOperacao Cadastrar(ProjetoTurma projetoTurma)
	{
		ResultadoOperacao resultadoOperacao = ValidarDatas(projetoTurma);
		if (resultadoOperacao.Erro)
		{
			return resultadoOperacao;
		}
		return projetoTurmaDAL.Cadastrar(projetoTurma);
	}

	public ResultadoOperacao Alterar(ProjetoTurma novoProjetoTurma)
	{
		ResultadoOperacao resultadoOperacao = ValidarDatas(novoProjetoTurma);
		if (resultadoOperacao.Erro)
		{
			return resultadoOperacao;
		}
		return projetoTurmaDAL.Alterar(novoProjetoTurma);
	}

	public List<PoloDTO> BuscarDadosPolosVinculados(long projetoTurmaUID)
	{
		List<PoloDTO> list = new List<PoloDTO>();
		foreach (ProjetoTurmaPolo item in projetoTurmaDAL.ListarTurmaPolo(projetoTurmaUID))
		{
			PoloDTO poloDTO = new PoloDTO();
			poloDTO.EnderecoUID = item.enderecoUID;
			poloDTO.ProjetoTurmaPoloUID = item.projetoTurmaPoloUID;
			poloDTO.IdentificacaoEndereco = item.EnderecoPoloApoioPresencialEAD.identificacaoEndereco;
			poloDTO.TotalVagasPolo = item.quantidadeVagas;
			poloDTO.TotalAlunosMatriculados = item.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID && e.tipoSituacaoInscricaoUID > 2).Count();
			poloDTO.TotalAlunosAtivos = item.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID && e.tipoSituacaoInscricaoUID == 3).Count();
			poloDTO.TotalAlunosInativos = item.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID && (e.tipoSituacaoInscricaoUID == 4 || e.tipoSituacaoInscricaoUID == 5)).Count();
			poloDTO.TotalAlunosFormados = item.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.ProjetoTurmaPolo.projetoTurmaUID == projetoTurmaUID && e.tipoSituacaoInscricaoUID == 7).Count();
			list.Add(poloDTO);
		}
		return list.OrderBy((PoloDTO e) => e.IdentificacaoEndereco).ToList();
	}

	public ResultadoOperacao ValidarPoloDuplicado(int enderecoUID, long projetoTurmaUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (projetoTurmaDAL.BucarProjetoTurmaPolo(enderecoUID, projetoTurmaUID) != null)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "O polo selecionado já está vinculado à esta turma.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao ValidarDatas(ProjetoTurma projetoTurma)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (projetoTurma.DataFim < projetoTurma.DataInicio)
		{
			resultadoOperacao.TextMessage = "Data de Fim não pode ser anterior a Data de Início";
			resultadoOperacao.Erro = true;
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		}
		return resultadoOperacao;
	}

	public ProjetoTurmaPolo BucarProjetoTurmaPolo(int enderecoUID, long projetoTurmaUID)
	{
		return projetoTurmaDAL.BucarProjetoTurmaPolo(enderecoUID, projetoTurmaUID);
	}
}

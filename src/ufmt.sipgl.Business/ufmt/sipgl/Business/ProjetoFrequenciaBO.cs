using System.Collections.Generic;
using System.Linq;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;

namespace ufmt.sipgl.Business;

public class ProjetoFrequenciaBO
{
	public ProjetoFrequenciaDAL projetoFrequenciaDAL { get; set; }

	public ProjetoFrequenciaBO()
	{
		projetoFrequenciaDAL = new ProjetoFrequenciaDAL();
	}

	public List<FrequenciaDTO> ListarFrequencias(List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma, long projetoEncontroPresencialUID)
	{
		List<FrequenciaDTO> list = new List<FrequenciaDTO>();
		foreach (ViewPreMatriculaInscricaoTurma item in listaViewPreMatriculaInscricaoTurma)
		{
			ProjetoFrequencia projetoFrequencia = projetoFrequenciaDAL.BuscarFrequenciaPorEncontroPresencial(projetoEncontroPresencialUID, item.preMatriculaInscricaoUID);
			FrequenciaDTO frequenciaDTO = new FrequenciaDTO();
			frequenciaDTO.ProjetoFrequenciaUID = projetoFrequencia?.projetoFrequenciaUID ?? 0;
			frequenciaDTO.PreMatriculaInscricaoUID = item.preMatriculaInscricaoUID;
			frequenciaDTO.ProjetoEncontroPresencialUID = projetoEncontroPresencialUID;
			frequenciaDTO.CPF = item.CPF;
			frequenciaDTO.NomeDiscente = item.nome;
			frequenciaDTO.TipoSituacaoInscricao = item.tipoSituacaoInscricao;
			frequenciaDTO.isPresente = projetoFrequencia?.isPresente;
			list.Add(frequenciaDTO);
		}
		return list;
	}

	public ResultadoOperacao AtualizarFrequencia(List<FrequenciaDTO> listaFrequenciaDTO, long usuarioUID, string ip)
	{
		new ResultadoOperacao();
		List<ProjetoFrequencia> list = new List<ProjetoFrequencia>();
		foreach (FrequenciaDTO item in listaFrequenciaDTO)
		{
			ProjetoFrequencia projetoFrequencia = new ProjetoFrequencia();
			projetoFrequencia.preMatriculaInscricaoUID = item.PreMatriculaInscricaoUID;
			projetoFrequencia.projetoEncontroPresencialUID = item.ProjetoEncontroPresencialUID;
			projetoFrequencia.isPresente = item.isPresente;
			list.Add(projetoFrequencia);
		}
		return projetoFrequenciaDAL.AtualizarFrequenciaPorDisciplina(list, usuarioUID, ip);
	}

	public List<ProjetoFrequencia> ListarNotasPorDiscente(long preMatriculaInscricaoUID)
	{
		return projetoFrequenciaDAL.ListarNotasPorDiscente(preMatriculaInscricaoUID);
	}

	public decimal CalcularFrequencia(long preMatriculaPessoaUID, long enderecoUID, long projetoDisciplinaUID)
	{
		List<ProjetoFrequencia> source = projetoFrequenciaDAL.ListarFrequenciaPorPoloDisciplinaDiscente(preMatriculaPessoaUID, enderecoUID, projetoDisciplinaUID);
		decimal num = source.Where((ProjetoFrequencia e) => e.ProjetoEncontroPresencial.isObrigatorio).Count();
		decimal num2 = source.Where((ProjetoFrequencia e) => e.ProjetoEncontroPresencial.isObrigatorio && e.isPresente == true).Count();
		if (!(num == 0m))
		{
			return num2 / num * 100m;
		}
		return 0m;
	}
}

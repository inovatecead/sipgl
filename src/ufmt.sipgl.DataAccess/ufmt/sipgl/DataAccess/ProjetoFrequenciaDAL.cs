using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoFrequenciaDAL
{
	public ProjetoFrequencia BuscarFrequenciaPorEncontroPresencial(long projetoEncontroPresencialUID, long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoFrequencia.Where((ProjetoFrequencia e) => e.projetoEncontroPresencialUID == projetoEncontroPresencialUID && e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public ResultadoOperacao AtualizarFrequenciaPorDisciplina(List<ProjetoFrequencia> listaProjetoFrequencia, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			foreach (ProjetoFrequencia item in listaProjetoFrequencia)
			{
				ProjetoFrequencia projetoFrequencia = contextInstance.ProjetoFrequencia.Where((ProjetoFrequencia e) => e.preMatriculaInscricaoUID == item.preMatriculaInscricaoUID && e.projetoEncontroPresencialUID == item.projetoEncontroPresencialUID).FirstOrDefault();
				if (projetoFrequencia == null)
				{
					ProjetoFrequencia projetoFrequencia2 = new ProjetoFrequencia();
					projetoFrequencia2.preMatriculaInscricaoUID = item.preMatriculaInscricaoUID;
					projetoFrequencia2.projetoEncontroPresencialUID = item.projetoEncontroPresencialUID;
					projetoFrequencia2.isPresente = item.isPresente;
					ProjetoFrequenciaHistorico projetoFrequenciaHistorico = new ProjetoFrequenciaHistorico();
					projetoFrequenciaHistorico.ProjetoFrequencia = projetoFrequencia2;
					projetoFrequenciaHistorico.dataInclusao = DateTime.Now;
					projetoFrequenciaHistorico.dataAlteracao = null;
					projetoFrequenciaHistorico.isPresente = projetoFrequencia2.isPresente;
					projetoFrequenciaHistorico.usuarioUID = usuarioUID;
					projetoFrequenciaHistorico.ip = ip;
					contextInstance.ProjetoFrequencia.Add(projetoFrequencia2);
					contextInstance.ProjetoFrequenciaHistorico.Add(projetoFrequenciaHistorico);
				}
				else
				{
					projetoFrequencia.isPresente = item.isPresente;
					ProjetoFrequenciaHistorico projetoFrequenciaHistorico2 = new ProjetoFrequenciaHistorico();
					projetoFrequenciaHistorico2.projetoFrequenciaUID = projetoFrequencia.projetoFrequenciaUID;
					projetoFrequenciaHistorico2.dataInclusao = null;
					projetoFrequenciaHistorico2.dataAlteracao = DateTime.Now;
					projetoFrequenciaHistorico2.isPresente = projetoFrequencia.isPresente;
					projetoFrequenciaHistorico2.usuarioUID = usuarioUID;
					projetoFrequenciaHistorico2.ip = ip;
					contextInstance.Entry(projetoFrequencia).State = (EntityState)16;
					contextInstance.ProjetoFrequenciaHistorico.Add(projetoFrequenciaHistorico2);
				}
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Frequências alteradas com sucesso.";
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

	public List<ProjetoFrequencia> ListarNotasPorDiscente(long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoFrequencia.Where((ProjetoFrequencia e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoFrequencia>();
		}
	}

	public List<ProjetoFrequencia> ListarFrequenciaPorPoloDisciplinaDiscente(long preMatriculaPessoaUID, long enderecoUID, long projetoDisciplinaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoFrequencia.Where((ProjetoFrequencia e) => e.PreMatriculaInscricao.preMatriculaPessoaUID == preMatriculaPessoaUID && e.ProjetoEncontroPresencial.projetoDisciplinaUID == projetoDisciplinaUID && (long)e.ProjetoEncontroPresencial.ProjetoTurmaPolo.enderecoUID == enderecoUID).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoFrequencia>();
		}
	}
}

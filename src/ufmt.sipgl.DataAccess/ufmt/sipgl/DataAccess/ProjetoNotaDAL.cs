using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoNotaDAL
{
	public ProjetoNota BuscarNotaPorDisciplina(long projetoDisciplinaUID, long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoNota.Where((ProjetoNota e) => e.projetoDisciplinaUID == projetoDisciplinaUID && e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public ResultadoOperacao AtualizarNotaPorDisciplina(List<ProjetoNota> listaProjetoNota, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			foreach (ProjetoNota item in listaProjetoNota)
			{
				ProjetoNota projetoNota = contextInstance.ProjetoNota.Where((ProjetoNota e) => e.preMatriculaInscricaoUID == item.preMatriculaInscricaoUID && e.projetoDisciplinaUID == item.projetoDisciplinaUID).FirstOrDefault();
				if (projetoNota == null)
				{
					ProjetoNota projetoNota2 = new ProjetoNota();
					projetoNota2.projetoDisciplinaUID = item.projetoDisciplinaUID;
					projetoNota2.preMatriculaInscricaoUID = item.preMatriculaInscricaoUID;
					projetoNota2.nota = item.nota;
					projetoNota2.conceito = item.conceito;
					projetoNota2.descricaoTCC = item.descricaoTCC;
					ProjetoNotaHistorico projetoNotaHistorico = new ProjetoNotaHistorico();
					projetoNotaHistorico.conceito = projetoNota2.conceito;
					projetoNotaHistorico.descricaoTCC = projetoNota2.descricaoTCC;
					projetoNotaHistorico.nota = projetoNota2.nota;
					projetoNotaHistorico.ProjetoNota = projetoNota2;
					projetoNotaHistorico.dataInclusao = DateTime.Now;
					projetoNotaHistorico.dataAlteracao = null;
					projetoNotaHistorico.usuarioUID = usuarioUID;
					projetoNotaHistorico.ip = ip;
					contextInstance.ProjetoNota.Add(projetoNota2);
					contextInstance.ProjetoNotaHistorico.Add(projetoNotaHistorico);
				}
				else
				{
					projetoNota.nota = item.nota;
					projetoNota.conceito = item.conceito;
					projetoNota.descricaoTCC = item.descricaoTCC;
					ProjetoNotaHistorico projetoNotaHistorico2 = new ProjetoNotaHistorico();
					projetoNotaHistorico2.conceito = projetoNota.conceito;
					projetoNotaHistorico2.descricaoTCC = projetoNota.descricaoTCC;
					projetoNotaHistorico2.nota = projetoNota.nota;
					projetoNotaHistorico2.projetoNotaUID = projetoNota.projetoNotaUID;
					projetoNotaHistorico2.dataInclusao = null;
					projetoNotaHistorico2.dataAlteracao = DateTime.Now;
					projetoNotaHistorico2.usuarioUID = usuarioUID;
					projetoNotaHistorico2.ip = ip;
					contextInstance.Entry(projetoNota).State = (EntityState)16;
					contextInstance.ProjetoNotaHistorico.Add(projetoNotaHistorico2);
				}
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Notas alteradas com sucesso.";
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

	public List<ProjetoNota> ListarNotasPorDiscente(long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoNota.Where((ProjetoNota e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoNota>();
		}
	}
}

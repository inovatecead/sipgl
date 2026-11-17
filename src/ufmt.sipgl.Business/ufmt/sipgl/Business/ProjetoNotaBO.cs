using System;
using System.Collections.Generic;
using System.Linq;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.DataAccess.Utils;

namespace ufmt.sipgl.Business;

public class ProjetoNotaBO
{
	public ProjetoNotaDAL ProjetoNotaDAL { get; set; }

	public ProjetoNotaBO()
	{
		ProjetoNotaDAL = new ProjetoNotaDAL();
	}

	public ProjetoNota BuscarNotaPorDisciplinaDiscente(long projetoDisciplinaUID, long preMatriculaInscricaoUID)
	{
		return ProjetoNotaDAL.BuscarNotaPorDisciplina(projetoDisciplinaUID, preMatriculaInscricaoUID);
	}

	public List<NotaDTO> ListarNotas(List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma, long projetoDisciplinaUID)
	{
		List<NotaDTO> list = new List<NotaDTO>();
		foreach (ViewPreMatriculaInscricaoTurma item in listaViewPreMatriculaInscricaoTurma)
		{
			ProjetoNota projetoNota = ProjetoNotaDAL.BuscarNotaPorDisciplina(projetoDisciplinaUID, item.preMatriculaInscricaoUID);
			NotaDTO notaDTO = new NotaDTO();
			notaDTO.ProjetoNotaUID = projetoNota?.projetoNotaUID ?? 0;
			notaDTO.PreMatriculaInscricaoUID = item.preMatriculaInscricaoUID;
			notaDTO.ProjetoDisciplinaUID = projetoDisciplinaUID;
			notaDTO.ProjetoTurmaUID = item.projetoTurmaUID;
			notaDTO.EnderecoUID = item.enderecoUID;
			notaDTO.CPF = item.CPF;
			notaDTO.NomeDiscente = item.nome;
			notaDTO.TipoSituacaoInscricao = item.tipoSituacaoInscricao;
			notaDTO.Nota = projetoNota?.nota;
			notaDTO.Conceito = projetoNota?.conceito;
			notaDTO.TituloTCC = projetoNota?.descricaoTCC;
			list.Add(notaDTO);
		}
		return list;
	}

	public ResultadoOperacao AtualizarNotaPorDisciplina(List<NotaDTO> listaNotaDTO, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		List<ProjetoNota> list = new List<ProjetoNota>();
		foreach (NotaDTO item in listaNotaDTO)
		{
			if (item.Nota < (decimal?)0m || item.Nota > (decimal?)100)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Nota máxima permitida é 100,00";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoNota projetoNota = new ProjetoNota();
			projetoNota.preMatriculaInscricaoUID = item.PreMatriculaInscricaoUID;
			projetoNota.projetoDisciplinaUID = item.ProjetoDisciplinaUID;
			projetoNota.nota = item.Nota;
			projetoNota.conceito = item.Conceito;
			projetoNota.descricaoTCC = item.TituloTCC;
			list.Add(projetoNota);
		}
		return ProjetoNotaDAL.AtualizarNotaPorDisciplina(list, usuarioUID, ip);
	}

	public List<ProjetoNota> ListarNotasPorDiscente(long preMatriculaInscricaoUID)
	{
		return ProjetoNotaDAL.ListarNotasPorDiscente(preMatriculaInscricaoUID);
	}

	public ResultadoOperacao ImportarNotas(List<string> registros, List<NotaDTO> listaNotaDTO, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		Util util = new Util();
		try
		{
			if (registros == null)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Erro ao importar notas.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
				return resultadoOperacao;
			}
			foreach (string registro in registros)
			{
				string[] array = registro.Split(new char[1] { ';' });
				string cpf = array[0];
				cpf = cpf.Replace(".", "");
				cpf = cpf.Replace("-", "");
				string text = array[1].Replace(".", ",");
				string text2 = array[2];
				string text3 = array[3];
				if (!util.ValidarCPF(cpf))
				{
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "CPF Inválido.";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
					return resultadoOperacao;
				}
				NotaDTO notaDTO = listaNotaDTO.Where((NotaDTO e) => e.CPF == cpf).FirstOrDefault();
				if (notaDTO == null)
				{
					continue;
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					notaDTO.Nota = null;
				}
				else
				{
					decimal num = decimal.Parse(text);
					if (num < 0m || num > 100m)
					{
						resultadoOperacao.Erro = true;
						resultadoOperacao.TextMessage = "Erro ao importar notas. Todas as notas devem estar entre 0 e 100.";
						resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
						return resultadoOperacao;
					}
					notaDTO.Nota = num;
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					switch (text2)
					{
					case "A":
					case "B":
					case "C":
						notaDTO.Conceito = text2;
						break;
					}
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					notaDTO.TituloTCC = text3;
				}
			}
			return AtualizarNotaPorDisciplina(listaNotaDTO, usuarioUID, ip);
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao importar notas.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			return resultadoOperacao;
		}
	}
}

using System;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTurmaDisciplinaDAL
{
	public ResultadoOperacao VincularDocente(ProjetoTurmaDisciplina projetoTurmaDisciplinaNovo)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (projetoTurmaDisciplinaNovo.dataTermino <= projetoTurmaDisciplinaNovo.dataInicio)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Data de término deve ser posterior a data de início";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (projetoTurmaDisciplinaNovo.projetoCorpoDocenteSecundarioUID.HasValue && !projetoTurmaDisciplinaNovo.possuiRemuneracaoDocenteSecundario.HasValue)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Obrigatório a seleção da remuneração para o docente secundário";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (projetoTurmaDisciplinaNovo.possuiRemuneracaoDocentePrincipal == 1 && !projetoTurmaDisciplinaNovo.tipoRemuneracaoDocentePrincipal.HasValue)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Obrigatório a seleção do tipo de remuneração para o docente principal";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (projetoTurmaDisciplinaNovo.possuiRemuneracaoDocenteSecundario == 1 && !projetoTurmaDisciplinaNovo.tipoRemuneracaoDocenteSecundario.HasValue)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Obrigatório a seleção do tipo de remuneração para o docente secundário";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (projetoTurmaDisciplinaNovo.tipoRemuneracaoDocentePrincipal == 3 && string.IsNullOrWhiteSpace(projetoTurmaDisciplinaNovo.descricaoOutrosTiposRemuneracaoPrincipal))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Obrigatório a descrição do tipo de remuneração para o docente principal";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (projetoTurmaDisciplinaNovo.tipoRemuneracaoDocenteSecundario == 3 && string.IsNullOrWhiteSpace(projetoTurmaDisciplinaNovo.descricaoOutrosTiposRemuneracaoSecundario))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Obrigatório a descrição do tipo de remuneração para o docente secundário";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (!projetoTurmaDisciplinaNovo.projetoCorpoDocenteSecundarioUID.HasValue)
			{
				projetoTurmaDisciplinaNovo.possuiRemuneracaoDocenteSecundario = null;
				projetoTurmaDisciplinaNovo.tipoRemuneracaoDocenteSecundario = null;
				projetoTurmaDisciplinaNovo.descricaoOutrosTiposRemuneracaoSecundario = null;
			}
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoTurmaDisciplina projetoTurmaDisciplina = contextInstance.ProjetoTurmaDisciplina.Where((ProjetoTurmaDisciplina e) => e.projetoTurmaUID == projetoTurmaDisciplinaNovo.projetoTurmaUID && e.projetoDisciplinaUID == projetoTurmaDisciplinaNovo.projetoDisciplinaUID).FirstOrDefault();
			if (projetoTurmaDisciplina == null)
			{
				contextInstance.ProjetoTurmaDisciplina.Add(projetoTurmaDisciplinaNovo);
			}
			else
			{
				projetoTurmaDisciplina.dataInicio = projetoTurmaDisciplinaNovo.dataInicio;
				projetoTurmaDisciplina.dataTermino = projetoTurmaDisciplinaNovo.dataTermino;
				projetoTurmaDisciplina.projetoCorpoDocenteUID = projetoTurmaDisciplinaNovo.projetoCorpoDocenteUID;
				projetoTurmaDisciplina.possuiRemuneracaoDocentePrincipal = projetoTurmaDisciplinaNovo.possuiRemuneracaoDocentePrincipal;
				projetoTurmaDisciplina.tipoRemuneracaoDocentePrincipal = projetoTurmaDisciplinaNovo.tipoRemuneracaoDocentePrincipal;
				projetoTurmaDisciplina.descricaoOutrosTiposRemuneracaoPrincipal = projetoTurmaDisciplinaNovo.descricaoOutrosTiposRemuneracaoPrincipal;
				projetoTurmaDisciplina.projetoCorpoDocenteSecundarioUID = projetoTurmaDisciplinaNovo.projetoCorpoDocenteSecundarioUID;
				projetoTurmaDisciplina.possuiRemuneracaoDocenteSecundario = projetoTurmaDisciplinaNovo.possuiRemuneracaoDocenteSecundario;
				projetoTurmaDisciplina.tipoRemuneracaoDocenteSecundario = projetoTurmaDisciplinaNovo.tipoRemuneracaoDocenteSecundario;
				projetoTurmaDisciplina.descricaoOutrosTiposRemuneracaoSecundario = projetoTurmaDisciplinaNovo.descricaoOutrosTiposRemuneracaoSecundario;
				contextInstance.Entry(projetoTurmaDisciplina).State = (EntityState)16;
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Docente vinculado com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do Sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ProjetoTurmaDisciplina BuscarTurmaDisciplinaPorId(long projetoTurmaDisciplinaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoTurmaDisciplina.Where((ProjetoTurmaDisciplina e) => e.projetoTurmaDisciplinaUID == projetoTurmaDisciplinaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoTurmaDisciplina BuscarTurmaDisciplinaPorTurmaDisciplina(long projetoTurmaUID, long projetoDisciplinaUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoTurmaDisciplina.Where((ProjetoTurmaDisciplina e) => e.projetoTurmaUID == projetoTurmaUID && e.projetoDisciplinaUID == projetoDisciplinaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}

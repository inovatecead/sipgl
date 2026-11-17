using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;

namespace ufmt.sig.business.implementation;

[Serializable]
public class EncargoBO : IEncargoBO, IDisposable
{
	private ISession session;

	public float CoeficientePreparacaoAula => 1.5f;

	public float MinimoCargaHorariaEnsino => 20f;

	public float MinimoCargaHorariaEnsinoSemPreparo => 8f;

	public float MinimoCargaHorariaEnsinoGraduacao => 10f;

	public float MinimoCargaHorariaEnsinoGraduacaoSemPreparo => 4f;

	public float CargaHorariaOrientacaoGraducao => 2f;

	public float CargaHorariaOrientacaoPosGraduacaoStricto => 3f;

	public float CargaHorariaOrientacaoPosGraduacaoLato => 2f;

	public float LimiteOrientacaoEnsino => 10f;

	public float LimitePesquisa => 10f;

	public float LimiteExtensao => 10f;

	internal EncargoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public float GetCargaHorariaOrientacao(MatrizDisciplinar matrizDisciplinar)
	{
		if (!NivelCursoEnum.GRADUACAO.Equals(matrizDisciplinar.MatrizCurricular.ModalidadeCurso.NivelCurso.Nivel))
		{
			if (!ModalidadeCursoEnum.ESPECIALIZACAO.Equals(matrizDisciplinar.MatrizCurricular.ModalidadeCurso.Modalidade))
			{
				return CargaHorariaOrientacaoPosGraduacaoStricto;
			}
			return CargaHorariaOrientacaoPosGraduacaoLato;
		}
		return CargaHorariaOrientacaoGraducao;
	}

	public ResumoEncargoServidor GetResumoEncargoServidor(long servidorUID, int ano, short? periodo)
	{
		return GetResumoEncargoServidor(servidorUID, ano, periodo, recDisciplinasAnuaisPrimeiroPeriodo: false);
	}

	public ResumoEncargoServidor GetResumoEncargoServidor(long servidorUID, int ano, short? periodo, bool recDisciplinasAnuaisPrimeiroPeriodo)
	{
		ResumoEncargoServidor resumoEncargoServidor = new ResumoEncargoServidor();
		resumoEncargoServidor.QuantidadePeriodos = (short)(periodo.HasValue ? 1 : 2);
		float num = 0f;
		using (ICursoBO cursoBO = BusinessFactory.GetInstance<ICursoBO>())
		{
			if (recDisciplinasAnuaisPrimeiroPeriodo && periodo.HasValue && periodo != 1)
			{
				List<AlocacaoDisciplinar> list = new List<AlocacaoDisciplinar>();
				list.AddRange(from ad in cursoBO.GetAlocacoesDisciplinares(ano, 1, servidorUID, 1, null, null, null, null)
					where ad.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade.Equals(PeriodicidadeCursoEnum.ANUAL)
					select ad);
				list.AddRange(cursoBO.GetAlocacoesDisciplinares(ano, periodo, servidorUID, null, null, null, null, null));
				resumoEncargoServidor.SetAlocacoesDisciplinares(list);
			}
			else
			{
				resumoEncargoServidor.SetAlocacoesDisciplinares(cursoBO.GetAlocacoesDisciplinares(ano, periodo, servidorUID, null, null, null, null, null));
			}
		}
		using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
		{
			Servidor servidor = pessoaBO.GetServidor(servidorUID);
			if (servidor == null)
			{
				throw new Exception("Não foi possível obter servidor com o identificador informado.");
			}
			resumoEncargoServidor.SetServidor(servidor);
			num = ((servidor.JornadaTrabalho.JornadaTrabalhoSiape == 99) ? 40 : servidor.JornadaTrabalho.JornadaTrabalhoSiape);
		}
		resumoEncargoServidor.SetEncargosServidor(GetEncargosServidor(ano, periodo, servidorUID, null, null, null));
		resumoEncargoServidor.TotalEnsino = resumoEncargoServidor.AlocacoesDisciplinares.Where((AlocacaoDisciplinar ad) => !ad.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade.Equals(PeriodicidadeCursoEnum.ANUAL)).Sum((AlocacaoDisciplinar ad) => ad.CargaHorariaSemanal) / (float)resumoEncargoServidor.QuantidadePeriodos;
		resumoEncargoServidor.TotalEnsino += resumoEncargoServidor.AlocacoesDisciplinares.Where((AlocacaoDisciplinar ad) => ad.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade.Equals(PeriodicidadeCursoEnum.ANUAL)).Sum((AlocacaoDisciplinar ad) => ad.CargaHorariaSemanal);
		resumoEncargoServidor.EncargoEnsino = resumoEncargoServidor.TotalEnsino;
		resumoEncargoServidor.EncargoEnsinoSemPreparo = resumoEncargoServidor.AlocacoesDisciplinares.Where((AlocacaoDisciplinar ad) => !ad.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade.Equals(PeriodicidadeCursoEnum.ANUAL)).Sum((AlocacaoDisciplinar ad) => ad.CargaHorariaSemanal / (1f + ad.CoeficientePreparacaoAula)) / (float)resumoEncargoServidor.QuantidadePeriodos;
		resumoEncargoServidor.EncargoEnsinoSemPreparo += resumoEncargoServidor.AlocacoesDisciplinares.Where((AlocacaoDisciplinar ad) => ad.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade.Equals(PeriodicidadeCursoEnum.ANUAL)).Sum((AlocacaoDisciplinar ad) => ad.CargaHorariaSemanal / (1f + ad.CoeficientePreparacaoAula));
		resumoEncargoServidor.TotalOrientacao = resumoEncargoServidor.EncargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.ORIENTACAO.Equals(es.TipoEncargoServidor.CategoriaEncargo)).Sum((EncargoServidor es) => es.CargaHorariaSemanal) / (float)resumoEncargoServidor.QuantidadePeriodos;
		if (resumoEncargoServidor.TotalOrientacao > LimiteOrientacaoEnsino)
		{
			resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_ORIENTACAO, $"As atividades de orientação foram computadas até o limite máximo de {LimiteOrientacaoEnsino} horas semanais.");
			resumoEncargoServidor.EncargoOrientacao = LimiteOrientacaoEnsino;
		}
		else
		{
			resumoEncargoServidor.EncargoOrientacao = resumoEncargoServidor.TotalOrientacao;
		}
		resumoEncargoServidor.TotalPesquisa = resumoEncargoServidor.EncargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.PESQUISA.Equals(es.TipoEncargoServidor.CategoriaEncargo)).Sum((EncargoServidor es) => es.CargaHorariaSemanal) / (float)resumoEncargoServidor.QuantidadePeriodos;
		if (resumoEncargoServidor.TotalPesquisa > LimitePesquisa)
		{
			resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_PESQUISA, $"As atividades de pesquisa foram computadas até o limite máximo de {LimitePesquisa} horas semanais.");
			resumoEncargoServidor.EncargoPesquisa = LimitePesquisa;
		}
		else
		{
			resumoEncargoServidor.EncargoPesquisa = resumoEncargoServidor.TotalPesquisa;
		}
		resumoEncargoServidor.TotalExtensao = resumoEncargoServidor.EncargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.EXTENSAO.Equals(es.TipoEncargoServidor.CategoriaEncargo)).Sum((EncargoServidor es) => es.CargaHorariaSemanal) / (float)resumoEncargoServidor.QuantidadePeriodos;
		if (resumoEncargoServidor.TotalExtensao > LimiteExtensao)
		{
			resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_EXTENSAO, $"As atividades de extensão foram computadas até o limite máximo de {LimiteExtensao} horas semanais.");
			resumoEncargoServidor.EncargoExtensao = LimiteExtensao;
		}
		else
		{
			resumoEncargoServidor.EncargoExtensao = resumoEncargoServidor.TotalExtensao;
		}
		resumoEncargoServidor.EncargoAdministracao = resumoEncargoServidor.EncargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.ATIVIDADE_ADMINISTRATIVA.Equals(es.TipoEncargoServidor.CategoriaEncargo)).Sum((EncargoServidor es) => es.CargaHorariaSemanal) / (float)resumoEncargoServidor.QuantidadePeriodos;
		if (num < 40f)
		{
			if (resumoEncargoServidor.EncargoEnsinoSemPreparo < MinimoCargaHorariaEnsinoSemPreparo)
			{
				resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_ENSINO, $"A carga horária em atividades de ensino está abaixo do mínimo de {MinimoCargaHorariaEnsino / (CoeficientePreparacaoAula + 1f)} horas semanais ({MinimoCargaHorariaEnsino} horas semanais equivalentes).");
			}
		}
		else if (resumoEncargoServidor.EncargosServidor.Count == 0)
		{
			if (resumoEncargoServidor.EncargoEnsinoSemPreparo < num / (CoeficientePreparacaoAula + 1f))
			{
				resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_ENSINO, $"A carga horária em atividades de ensino está abaixo do mínimo de {num / (CoeficientePreparacaoAula + 1f)} horas semanais ({num} horas semanais equivalentes) com atividades exclusivamente de ensino.");
			}
		}
		else
		{
			float num2;
			try
			{
				num2 = resumoEncargoServidor.EncargosAdministracao.Select((EncargoServidor es) => es).Max((EncargoServidor es) => es.TipoEncargoServidor.ReducaoCargaHorariaEnsino);
				num2 /= 1f + CoeficientePreparacaoAula;
			}
			catch
			{
				num2 = 0f;
			}
			if (resumoEncargoServidor.EncargoEnsinoSemPreparo < MinimoCargaHorariaEnsinoSemPreparo - num2)
			{
				resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_ENSINO, $"A carga horária em atividades de ensino está abaixo do mínimo de {MinimoCargaHorariaEnsinoSemPreparo - num2} horas semanais ({(MinimoCargaHorariaEnsinoSemPreparo - num2) * (CoeficientePreparacaoAula + 1f)} horas semanais equivalentes).");
			}
			float num3 = resumoEncargoServidor.AlocacoesDisciplinaresGraduacao.Where((AlocacaoDisciplinar ad) => !ad.TipoAlocacaoDisciplinar.RequerOrientacao).Sum((AlocacaoDisciplinar ad) => ad.CargaHorariaSemanal / (1f + ad.CoeficientePreparacaoAula)) / (float)resumoEncargoServidor.QuantidadePeriodos;
			float num4 = resumoEncargoServidor.AlocacoesDisciplinaresGraduacao.Where((AlocacaoDisciplinar ad) => ad.TipoAlocacaoDisciplinar.RequerOrientacao).Sum((AlocacaoDisciplinar ad) => ad.CargaHorariaSemanal) / (float)resumoEncargoServidor.QuantidadePeriodos;
			num4 = ((num4 > LimiteOrientacaoEnsino) ? LimiteOrientacaoEnsino : num4);
			if (num3 + num4 < MinimoCargaHorariaEnsinoGraduacaoSemPreparo - num2)
			{
				resumoEncargoServidor.AddCritica(CategoriaCriticaEncargo.ENCARGO_ENSINO, $"A carga horária em atividades de ensino na graduação está abaixo do mínimo de {MinimoCargaHorariaEnsinoGraduacaoSemPreparo - num2} horas semanais ({(MinimoCargaHorariaEnsinoGraduacaoSemPreparo - num2) * (CoeficientePreparacaoAula + 1f)} horas semanais equivalentes).");
			}
		}
		if (resumoEncargoServidor.Encargo < num)
		{
			resumoEncargoServidor.AddCritica((CategoriaCriticaEncargo)15, $"A carga horária semanal está abaixo das {num} horas semanais convencionadas.");
		}
		resumoEncargoServidor.AddCritica((CategoriaCriticaEncargo)15, "Resumo gerado de acordo com a Resolução CONSEPE Nº197, de 01 de dezembro de 2009.");
		return resumoEncargoServidor;
	}

	public TipoEncargoServidor GetTipoEncargoServidor(int tipoEncargoServidorUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select tes from TipoEncargoServidor tes where tes.TipoEncargoServidorUID = :tipoEncargoServidorUID").SetParameter("tipoEncargoServidorUID", tipoEncargoServidorUID);
			return query.UniqueResult<TipoEncargoServidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar encargo do servidor.", innerException);
		}
	}

	public IList<TipoEncargoServidor> GetTiposEncargosServidor(CategoriaEncargoEnum? categoriaEncargo)
	{
		try
		{
			IQuery query = session.CreateQuery("select tes from TipoEncargoServidor tes where (:categoriaEncargo is null or (tes.CategoriaEncargoUID & :categoriaEncargo) <> 0 ) order by tes.CategoriaEncargoUID, tes.Descricao").SetParameter("categoriaEncargo", categoriaEncargo.HasValue ? new int?((int)categoriaEncargo.Value) : ((int?)null));
			return query.List<TipoEncargoServidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar tipos de encargos de servidor.", innerException);
		}
	}

	public EncargoServidor GetEncargoServidor(long encargoServidorUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select es from EncargoServidor es where es.EncargoServidorUID = :encargoServidorUID").SetParameter("encargoServidorUID", encargoServidorUID);
			return query.UniqueResult<EncargoServidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar encargo de servidor.", innerException);
		}
	}

	public IList<EncargoServidor> GetEncargosServidor(int ano, short? periodo, long? servidorUID, CategoriaEncargoEnum? categoriaEncargo, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select es from EncargoServidor es where es.Ano = :ano   and (:periodo is null or es.Periodo = :periodo)   and (:servidorUID is null or es.Servidor.ServidorUID = :servidorUID)   and (:categoriaEncargo is null or (es.TipoEncargoServidor.CategoriaEncargoUID & :categoriaEncargo) <> 0) order by es.Ano, es.Periodo, es.TipoEncargoServidor.CategoriaEncargoUID, es.TipoEncargoServidor.Descricao").SetParameter("ano", ano).SetParameter("periodo", (int?)periodo)
				.SetParameter("servidorUID", servidorUID)
				.SetParameter("categoriaEncargo", categoriaEncargo.HasValue ? new int?((int)categoriaEncargo.Value) : ((int?)null));
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<EncargoServidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar encargos de servidor.", innerException);
		}
	}

	public void SalveEncargoServidor(EncargoServidor encargoServidor)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			if (encargoServidor.TipoEncargoServidor == null)
			{
				throw new Exception("O tipo de encargo não foi definido.");
			}
			if (encargoServidor.TipoEncargoServidor.CargaHorariaFixa && encargoServidor.CargaHorariaSemanal != encargoServidor.TipoEncargoServidor.CargaHoraria.Value)
			{
				throw new Exception($"O tipo de encargo requer carga horária semanal fixa de {encargoServidor.TipoEncargoServidor.CargaHoraria.Value} horas.");
			}
			if (encargoServidor.TipoEncargoServidor.CargaHoraria.HasValue && encargoServidor.CargaHorariaSemanal > encargoServidor.TipoEncargoServidor.CargaHoraria.Value)
			{
				throw new Exception($"A carga horária semanal para o encargo não pode ser superior à {encargoServidor.TipoEncargoServidor.CargaHoraria.Value} horas.");
			}
			if (encargoServidor.CargaHorariaSemanal <= 0f)
			{
				throw new Exception("A carga horária semanal deve ser superior à 0,00 horas.");
			}
			if (encargoServidor.TipoEncargoServidor.RequerDetalhamento && string.IsNullOrEmpty(encargoServidor.Descricao))
			{
				throw new Exception("A descrição da atividade deve ser informada.");
			}
			session.SaveOrUpdate(encargoServidor);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar encargo para o servidor.", innerException);
		}
	}

	public void RemovaEncargoServidor(long encargoServidorUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			EncargoServidor encargoServidor = GetEncargoServidor(encargoServidorUID);
			if (encargoServidor != null)
			{
				session.Delete(encargoServidor);
			}
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível remover encargo para servidor.", innerException);
		}
	}

	public IList<int> GetAnosDeclaracaoEncargos()
	{
		List<int> list = new List<int>();
		list.AddRange(session.CreateQuery("select distinct ad.Ano from AlocacaoDisciplinar ad").List<int>());
		list.AddRange(session.CreateQuery("select distinct es.Ano from EncargoServidor es").List<int>());
		return list.Select((int a) => a).Distinct().ToList();
	}

	public IList<short> GetPeriodosDeclaracaoEncargos(int ano)
	{
		List<short> list = new List<short>();
		list.AddRange(session.CreateQuery("select distinct ad.Periodo from AlocacaoDisciplinar ad where ad.Ano = :ano").SetParameter("ano", ano).List<short>());
		list.AddRange(session.CreateQuery("select distinct es.Periodo from EncargoServidor es where es.Ano = :ano").SetParameter("ano", ano).List<short>());
		return list.Select((short p) => p).Distinct().ToList();
	}

	public void SalvePiaAprovadoServidor(int ano, short periodo, Servidor servidorDocente, Servidor servidorAprovador, bool avaliacaoAprovador, string justificativa, string observacaoDocente)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (servidorDocente == null)
			{
				throw new Exception("O docente não foi especificado.");
			}
			HomologacaoPia homologacaoPia = GetHomologacaoPia(ano, periodo, servidorDocente.ServidorUID);
			if (homologacaoPia == null)
			{
				homologacaoPia = new HomologacaoPia();
			}
			homologacaoPia.Ano = ano;
			homologacaoPia.Periodo = periodo;
			homologacaoPia.ServidorDocente = servidorDocente;
			homologacaoPia.ServidorAprovador = servidorAprovador;
			homologacaoPia.AvaliacaoAprovador = avaliacaoAprovador;
			homologacaoPia.JustificativaAprovador = justificativa;
			if (observacaoDocente != null)
			{
				homologacaoPia.ObservacaoDocente = observacaoDocente;
			}
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(homologacaoPia);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar a aprovação dos encargos do docente.", innerException);
		}
	}

	public void SalvePiaHomologadoServidor(int ano, short periodo, Servidor servidorDocente, Servidor serividorHomologador, bool avaliacaoHomologador, string justificativa, string observacaoDocente)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (servidorDocente == null)
			{
				throw new Exception("O docente não foi especificado.");
			}
			HomologacaoPia homologacaoPia = GetHomologacaoPia(ano, periodo, servidorDocente.ServidorUID);
			if (homologacaoPia == null)
			{
				homologacaoPia = new HomologacaoPia();
			}
			homologacaoPia.Ano = ano;
			homologacaoPia.Periodo = periodo;
			homologacaoPia.ServidorDocente = servidorDocente;
			homologacaoPia.ServidorHomologador = serividorHomologador;
			homologacaoPia.AvaliacaoHomologador = avaliacaoHomologador;
			homologacaoPia.JustificativaHomologador = justificativa;
			if (observacaoDocente != null)
			{
				homologacaoPia.ObservacaoDocente = observacaoDocente;
			}
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(homologacaoPia);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar a homologação dos encargos do docente.", innerException);
		}
	}

	public HomologacaoPia GetHomologacaoPia(int ano, int periodo, long servidorUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select hp from HomologacaoPia hp where hp.Ano = :ano   and (hp.Periodo = :periodo)   and (hp.ServidorDocente.ServidorUID = :servidorUID)").SetParameter("ano", ano).SetParameter("periodo", (int?)periodo)
				.SetParameter("servidorUID", (long?)servidorUID);
			return query.UniqueResult<HomologacaoPia>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro do Planejamento de Encargos Homologado do docente.", innerException);
		}
	}

	public Afastamento getAfastamento(long afastamentoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select af from Afastamento af where af.AfastamentoUID = :afastamentoUID").SetParameter("afastamentoUID", afastamentoUID);
			return query.UniqueResult<Afastamento>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o afastamento.", innerException);
		}
	}

	public IList<Afastamento> getAfastamentos(long servidorUID, int ano, short? periodo)
	{
		try
		{
			IQuery query = session.CreateQuery("select af from Afastamento af where af.Servidor.ServidorUID = :servidorUID and af.Ano = :ano and (:periodo is null or af.Periodo = :periodo)").SetParameter("servidorUID", servidorUID).SetParameter("ano", ano)
				.SetParameter("periodo", periodo);
			return query.List<Afastamento>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os afastamentos.", innerException);
		}
	}

	public void addAfastamento(long servidorUID, int ano, short periodo, DateTime dataInicial, DateTime? dataFinal, string justificativa, string documentoComprobatorio)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		using IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>();
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Servidor servidor = pessoaBO.GetServidor(servidorUID);
			if (servidor == null)
			{
				throw new Exception("Servidor com identificação informada não foi encontrado.");
			}
			if (dataFinal.HasValue && dataFinal < dataInicial)
			{
				throw new Exception("A data final deve ser maior que a data inicial.");
			}
			Afastamento afastamento = new Afastamento();
			afastamento.Ano = ano;
			afastamento.Periodo = periodo;
			afastamento.Servidor = servidor;
			afastamento.DataInicial = dataInicial;
			afastamento.DataFinal = dataFinal;
			afastamento.Justificativa = justificativa;
			afastamento.DocumentoComprobatorio = documentoComprobatorio;
			session.SaveOrUpdate(afastamento);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar as informações de afastamento do servidor.", innerException);
		}
	}

	public void atualizeAfastamento(long afastamentoUID, DateTime dataInicial, DateTime? dataFinal, string justificativa, string documentoComprobatorio)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			Afastamento afastamento = getAfastamento(afastamentoUID);
			if (afastamento == null)
			{
				throw new Exception("Afastamento com identificação informada não foi encontrado.");
			}
			if (dataFinal.HasValue && dataFinal < dataInicial)
			{
				throw new Exception("A data final deve ser maior que a data inicial.");
			}
			afastamento.DataInicial = dataInicial;
			afastamento.DataFinal = dataFinal;
			afastamento.Justificativa = justificativa;
			afastamento.DocumentoComprobatorio = documentoComprobatorio;
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(afastamento);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar as informações de afastamento do servidor.", innerException);
		}
	}

	public void removaAfastamento(long afastamentoUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Afastamento afastamento = getAfastamento(afastamentoUID);
			if (afastamento != null)
			{
				session.Delete(afastamento);
			}
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível remover o afastamento.", innerException);
		}
	}
}

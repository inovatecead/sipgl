using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;

namespace ufmt.sig.business.implementation;

[Serializable]
public class CursoBO : ICursoBO, IDisposable
{
	private ISession session;

	internal CursoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public void CrieDivisaoDisciplinarSubTurmas(long alocacaoDisciplinarPrincipalUID, int quantidadeSubTurmas, IList<string> identificacoesSubTurmas, string justificativa, long servidorEditorUID, bool isCoordenador)
	{
		if (quantidadeSubTurmas < 2)
		{
			throw new Exception("É necessário informar uma quantidade de sub-turmas maior que 1 (um).");
		}
		if (quantidadeSubTurmas != identificacoesSubTurmas.Count)
		{
			throw new Exception("Os número de identificações das sub-turmas não coincidem com a quantidade de sub-turmas.");
		}
		AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarPrincipalUID);
		alocacaoDisciplinar.JustificativaFracionamento = justificativa;
		IList<DivisaoDisciplinar> list = new List<DivisaoDisciplinar>();
		for (int i = 0; i < quantidadeSubTurmas; i++)
		{
			list.Add(new DivisaoDisciplinar(alocacaoDisciplinar.TipoAlocacaoDisciplinar, alocacaoDisciplinar.CargaHoraria, identificacoesSubTurmas[i]));
		}
		SalveDivisoesDisciplinares(alocacaoDisciplinar, TipoFracionamentoDisciplinar.GetInstance(TipoFracionamentoDisciplinarEnum.CRIACAO_SUB_TURMA), list, servidorEditorUID, isCoordenador);
	}

	public void CrieDivisaoDisciplinarCoMinistrada(long alocacaoDisciplinarPrincipalUID, int quantidadeProfessores, long servidorEditorUID, bool isCoordenador)
	{
		if (quantidadeProfessores < 2)
		{
			throw new Exception("É necessário informar uma quantidade de professores maior que 1 (um).");
		}
		AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarPrincipalUID);
		IList<DivisaoDisciplinar> list = new List<DivisaoDisciplinar>();
		for (int i = 0; i < quantidadeProfessores; i++)
		{
			list.Add(new DivisaoDisciplinar(alocacaoDisciplinar.TipoAlocacaoDisciplinar, alocacaoDisciplinar.CargaHoraria, null));
		}
		SalveDivisoesDisciplinares(alocacaoDisciplinar, TipoFracionamentoDisciplinar.GetInstance(TipoFracionamentoDisciplinarEnum.DISCIPLINA_CO_MINISTRADA), list, servidorEditorUID, isCoordenador);
	}

	public void CrieDivisaoDisciplinarFracionamento(long alocacaoDisciplinarPrincipalUID, IList<DivisaoDisciplinar> divisoesDisciplinares, long servidorEditorUID, bool isCoordenador)
	{
		AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarPrincipalUID);
		float num = divisoesDisciplinares.Select((DivisaoDisciplinar dd) => dd.CargaHoraria).Sum();
		if (num != alocacaoDisciplinar.CargaHoraria)
		{
			throw new Exception("Na divisão por fracionamento de carga horária a soma das cargas horárias das divisões disciplinares devem ser igual a carga horária da alocação disciplinar sendo dividida.");
		}
		SalveDivisoesDisciplinares(alocacaoDisciplinar, TipoFracionamentoDisciplinar.GetInstance(TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_CARGA_HORARIA), divisoesDisciplinares, servidorEditorUID, isCoordenador);
	}

	public void CrieDivisaoDisciplinarFracionamentoModificado(long alocacaoDisciplinarPrincipalUID, IList<DivisaoDisciplinar> divisoesDisciplinares, long servidorEditorUID, bool isCoordenador)
	{
		AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarPrincipalUID);
		float num = divisoesDisciplinares.Select((DivisaoDisciplinar dd) => dd.CargaHoraria).Sum();
		if (num <= 0f)
		{
			throw new Exception("A soma das cargas horárias deve ser maior que zero.");
		}
		SalveDivisoesDisciplinaresFracionamentoModificado(alocacaoDisciplinar, TipoFracionamentoDisciplinar.GetInstance(TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_MODIFICADO), divisoesDisciplinares, servidorEditorUID, isCoordenador);
	}

	public void RemovaDivisaoDisciplinar(long alocacaoDisciplinarUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarUID);
			if (alocacaoDisciplinar.AlocacaoDisciplinarPrincipal == null)
			{
				throw new Exception("A alocação não é uma divisão disciplinar e não pode ser excluída.");
			}
			long alocacaoDisciplinarUID2 = alocacaoDisciplinar.AlocacaoDisciplinarPrincipal.AlocacaoDisciplinarUID;
			session.Delete(alocacaoDisciplinar);
			RemovaDivisoesExcedentes(alocacaoDisciplinarUID2);
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
			throw new Exception("Não foi possível remover divisão disciplinar.", innerException);
		}
	}

	protected void RemovaDivisoesExcedentes(long alocacaoDiciplinarPrincipalUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDiciplinarPrincipalUID);
			IList<AlocacaoDisciplinar> divisoesDisciplinares = GetDivisoesDisciplinares(alocacaoDiciplinarPrincipalUID);
			TipoFracionamentoDisciplinarEnum tipoFracionamentoDisciplinarEnum = divisoesDisciplinares.Select((AlocacaoDisciplinar dd) => dd.TipoFracionamentoDisciplinar.TipoFracionamento).Take(1).Single();
			if ((TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_CARGA_HORARIA.Equals(tipoFracionamentoDisciplinarEnum) && divisoesDisciplinares.Sum((AlocacaoDisciplinar ad) => ad.CargaHoraria) != alocacaoDisciplinar.CargaHoraria) || (divisoesDisciplinares.Count == 1 && (TipoFracionamentoDisciplinarEnum.CRIACAO_SUB_TURMA.Equals(tipoFracionamentoDisciplinarEnum) || TipoFracionamentoDisciplinarEnum.DISCIPLINA_CO_MINISTRADA.Equals(tipoFracionamentoDisciplinarEnum) || TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_MODIFICADO.Equals(tipoFracionamentoDisciplinarEnum))))
			{
				foreach (AlocacaoDisciplinar item in divisoesDisciplinares)
				{
					session.Delete(item);
				}
				alocacaoDisciplinar.Fracionada = false;
				session.SaveOrUpdate(alocacaoDisciplinar);
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
			throw new Exception("Não foi possível remover as divisões disciplinares excedentes.", innerException);
		}
	}

	public bool verificarRemocaoCascata(long alocacaoDisciplinarUID)
	{
		AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarUID);
		AlocacaoDisciplinar alocacaoDisciplinarPrincipal = alocacaoDisciplinar.AlocacaoDisciplinarPrincipal;
		IList<AlocacaoDisciplinar> divisoesDisciplinares = GetDivisoesDisciplinares(alocacaoDisciplinarPrincipal.AlocacaoDisciplinarUID);
		divisoesDisciplinares.Remove(alocacaoDisciplinar);
		TipoFracionamentoDisciplinarEnum tipoFracionamentoDisciplinarEnum = divisoesDisciplinares.Select((AlocacaoDisciplinar dd) => dd.TipoFracionamentoDisciplinar.TipoFracionamento).Take(1).Single();
		if ((TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_CARGA_HORARIA.Equals(tipoFracionamentoDisciplinarEnum) && divisoesDisciplinares.Sum((AlocacaoDisciplinar ad) => ad.CargaHoraria) != alocacaoDisciplinarPrincipal.CargaHoraria) || (divisoesDisciplinares.Count == 1 && (TipoFracionamentoDisciplinarEnum.CRIACAO_SUB_TURMA.Equals(tipoFracionamentoDisciplinarEnum) || TipoFracionamentoDisciplinarEnum.DISCIPLINA_CO_MINISTRADA.Equals(tipoFracionamentoDisciplinarEnum) || TipoFracionamentoDisciplinarEnum.FRACIONAMENTO_MODIFICADO.Equals(tipoFracionamentoDisciplinarEnum))))
		{
			return true;
		}
		return false;
	}

	public bool verificarProfessorAlocadoCascata(long alocacaoPrincipalUID)
	{
		IList<AlocacaoDisciplinar> divisoesDisciplinares = GetDivisoesDisciplinares(alocacaoPrincipalUID);
		foreach (AlocacaoDisciplinar item in divisoesDisciplinares)
		{
			if (item.Fracionada)
			{
				if (verificarProfessorAlocadoCascata(item.AlocacaoDisciplinarUID))
				{
					return true;
				}
			}
			else if (item.ServidorDocente != null)
			{
				return true;
			}
		}
		return false;
	}

	public bool verificarPermissaoRemocaoCascata(long alocacaoPrincipalUID)
	{
		IList<AlocacaoDisciplinar> divisoesDisciplinares = GetDivisoesDisciplinares(alocacaoPrincipalUID);
		foreach (AlocacaoDisciplinar item in divisoesDisciplinares)
		{
			if (item.IsCoordenadorFracionou)
			{
				return true;
			}
			if (item.Fracionada && verificarPermissaoRemocaoCascata(item.AlocacaoDisciplinarUID))
			{
				return true;
			}
		}
		return false;
	}

	public void marqueAlocacaoComoNaoFracionada(long alocacaoPrincipalUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoPrincipalUID);
			alocacaoDisciplinar.Fracionada = false;
			session.SaveOrUpdate(alocacaoDisciplinar);
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
			throw new Exception("Não foi possível remover as divisões disciplinares.", innerException);
		}
	}

	public void removeAlocacaoEmCascata(long alocacaoPrincipalUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoPrincipalUID);
			IList<AlocacaoDisciplinar> divisoesDisciplinares = GetDivisoesDisciplinares(alocacaoPrincipalUID);
			foreach (AlocacaoDisciplinar item in divisoesDisciplinares)
			{
				removeAlocacaoEmCascata(item.AlocacaoDisciplinarUID);
			}
			session.Delete(alocacaoDisciplinar);
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
			throw new Exception("Não foi possível remover as divisões disciplinares.", innerException);
		}
	}

	public IList<AlocacaoDisciplinar> GetDivisoesDisciplinares(long alocacaoDisciplinarPrincipalUID)
	{
		IQuery query = session.CreateQuery("select ad from AlocacaoDisciplinar ad where ad.AlocacaoDisciplinarPrincipal.AlocacaoDisciplinarUID = :alocacaoDisciplinarPrincipalUID").SetParameter("alocacaoDisciplinarPrincipalUID", alocacaoDisciplinarPrincipalUID);
		return query.List<AlocacaoDisciplinar>();
	}

	public Curso GetCurso(long cursoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select c from Curso c where (:cursoUID = cursoUID)").SetParameter("cursoUID", cursoUID);
			return query.UniqueResult<Curso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o curso.", innerException);
		}
	}

	public PlanoPedagogico GetPlanoPedagogicoMaisAtual(long codigoExterno, int nivelCursoUID, int formatoCursoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select pp from PlanoPedagogico pp where (pp.MatrizCurricular.Curso.CodigoExterno = :codigoExterno)   and (pp.MatrizCurricular.Curso.NivelCursoUID = :nivelCursoUID)   and (pp.MatrizCurricular.FormatoCursoUID = :formatoCursoUID) order by pp.MatrizCurricular.PeriodoInicialFuncionamento desc").SetParameter("codigoExterno", codigoExterno).SetParameter("formatoCursoUID", formatoCursoUID)
				.SetParameter("nivelCursoUID", (int?)nivelCursoUID);
			return (query.List<PlanoPedagogico>().Count > 0) ? query.List<PlanoPedagogico>().First() : null;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o plano pedagógico.", innerException);
		}
	}

	public IList<Curso> GetCursos(int? campusUID, long? unidadeOfertanteUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct c from Curso c where (:campusUID is null or c.Campus.CampusUID = :campusUID)   and (:unidadeOfertanteUID is null or c.UnidadeOfertante.UnidadeUID = :unidadeOfertanteUID)").SetParameter("campusUID", campusUID).SetParameter("unidadeOfertanteUID", unidadeOfertanteUID);
			return query.List<Curso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar cursos.", innerException);
		}
	}

	public IList<Curso> GetCursos(int? campusUID, int? nivelCursoUID, long? pessoaCoordenadorUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct cc.Curso from CoordenadorCurso cc where (:campusUID is null or cc.Curso.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or cc.Curso.NivelCursoUID = :nivelCursoUID)   and (:pessoaCoordenadorUID is null or cc.Pessoa.PessoaUID = :pessoaCoordenadorUID)").SetParameter("campusUID", campusUID).SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameter("pessoaCoordenadorUID", pessoaCoordenadorUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Curso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar cursos.", innerException);
		}
	}

	public IList<Curso> GetCursos(int? campusUID, int? nivelCursoUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct c from Curso c where (:campusUID is null or c.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or c.NivelCursoUID = :nivelCursoUID)").SetParameter("campusUID", campusUID).SetParameter("nivelCursoUID", nivelCursoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Curso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar cursos.", innerException);
		}
	}

	public MatrizCurricular GetMatrizCurricular(long matrizCurricularUID)
	{
		try
		{
			return session.Get<MatrizCurricular>(matrizCurricularUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matriz curricular.", innerException);
		}
	}

	public IList<MatrizCurricular> GetMatrizesCurriculares(int? campusUID, int? nivelCursoUID, long? cursoUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct mc from MatrizCurricular mc where (:campusUID is null or mc.Curso.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or mc.Curso.NivelCursoUID = :nivelCursoUID)   and (:cursoUID is null or mc.Curso.CursoUID = :cursoUID)").SetParameter("campusUID", campusUID).SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameter("cursoUID", cursoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<MatrizCurricular>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matrizes curriculares.", innerException);
		}
	}

	public IList<MatrizCurricular> GetMatrizesCurricularesAtivas(int? campusUID, int? nivelCursoUID, long? cursoUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct mc from MatrizCurricular mc where (:campusUID is null or mc.Curso.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or mc.Curso.NivelCursoUID = :nivelCursoUID)   and (mc.SituacaoCursoUID = :situacaoCursoUID)   and (:cursoUID is null or mc.Curso.CursoUID = :cursoUID)").SetParameter("situacaoCursoUID", SituacaoCursoEnum.ATIVO).SetParameter("campusUID", campusUID)
				.SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameter("cursoUID", cursoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<MatrizCurricular>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matrizes curriculares.", innerException);
		}
	}

	public IList<MatrizDisciplinar> GetMatrizesDisciplinares(int? campusUID, int? nivelCursoUID, long? cursoUID, long? matrizCurricularUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select md from MatrizDisciplinar md where (:campusUID is null or md.MatrizCurricular.Curso.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or md.MatrizCurricular.Curso.NivelCursoUID = :nivelCursoUID)   and (:cursoUID is null or md.MatrizCurricular.Curso.CursoUID = :cursoUID)   and (:matrizCurricularUID is null or md.MatrizCurricular.MatrizCurricularUID = :matrizCurricularUID)").SetParameter("campusUID", campusUID).SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameter("cursoUID", cursoUID)
				.SetParameter("matrizCurricularUID", matrizCurricularUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<MatrizDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matrizes disciplinares.", innerException);
		}
	}

	public void CrieAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID)
	{
		CriarAlocacaoDisciplinar(ano, periodo, matrizDisciplinarUID, null);
	}

	public void CrieAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID, float cargaHoraria)
	{
		CriarAlocacaoDisciplinar(ano, periodo, matrizDisciplinarUID, cargaHoraria);
	}

	private void CriarAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID, float? cargaHorariaAlocacao)
	{
		if (ExisteAlocacaoDisciplinar(ano, periodo, matrizDisciplinarUID))
		{
			return;
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			MatrizDisciplinar matrizDisciplinar = GetMatrizDisciplinar(matrizDisciplinarUID);
			if (matrizDisciplinar == null)
			{
				throw new Exception("Não existe matriz disciplinar com o identificador informado.");
			}
			AlocacaoDisciplinar alocacaoDisciplinar = new AlocacaoDisciplinar();
			alocacaoDisciplinar.MatrizDisciplinar = matrizDisciplinar;
			alocacaoDisciplinar.Ano = ano;
			alocacaoDisciplinar.Periodo = periodo;
			alocacaoDisciplinar.CargaHoraria = (cargaHorariaAlocacao.HasValue ? cargaHorariaAlocacao.Value : matrizDisciplinar.CargaHorariaTotal);
			alocacaoDisciplinar.TipoAlocacaoDisciplinar = (matrizDisciplinar.TipoDisciplina.RequerOrientacao ? TipoAlocacaoDisciplinar.GetInstance(TipoAlocacaoDisciplinarEnum.ORIENTACAO) : TipoAlocacaoDisciplinar.GetInstance(TipoAlocacaoDisciplinarEnum.AULA));
			alocacaoDisciplinar.Fracionada = matrizDisciplinar.TipoDisciplina.RequerOrientacao;
			alocacaoDisciplinar.TipoFracionamentoDisciplinar = TipoFracionamentoDisciplinar.GetInstance(TipoFracionamentoDisciplinarEnum.NENHUM);
			SalveAlocacaoDisciplinar(alocacaoDisciplinar, horaPreparoPadrao: true, forcarSemestral: false);
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
			throw new Exception("Não foi possível criar alocação disciplinar.", innerException);
		}
	}

	public void RemovaAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID)
	{
		if (!ExisteAlocacaoDisciplinar(ano, periodo, matrizDisciplinarUID))
		{
			return;
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			foreach (AlocacaoDisciplinar alocacoesDisciplinare in GetAlocacoesDisciplinares(ano, periodo, matrizDisciplinarUID))
			{
				session.Delete(alocacoesDisciplinare);
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
			throw new Exception("Não foi possível remover alocação disciplinar.", innerException);
		}
	}

	public IList<AlocacaoDisciplinar> GetAlocacoesDisciplinares(int ano, short periodo, long matrizDisciplinarUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad from AlocacaoDisciplinar ad where ad.Ano = :ano   and ad.Periodo = :periodo   and ad.MatrizDisciplinar.MatrizDisciplinarUID = :matrizDisciplinarUID order by ad.AlocacaoDisciplinarPrincipal.AlocacaoDisciplinarUID").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("matrizDisciplinarUID", matrizDisciplinarUID);
			return query.List<AlocacaoDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar alocações disciplinares para a matriz disciplinar.", innerException);
		}
	}

	public bool ExisteAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select count(ad) from AlocacaoDisciplinar ad where ad.Ano = :ano   and ad.Periodo = :periodo   and ad.MatrizDisciplinar.MatrizDisciplinarUID = :matrizDisciplinarUID").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("matrizDisciplinarUID", matrizDisciplinarUID);
			return query.UniqueResult<int>() > 0;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar existência da alocação disciplinar.", innerException);
		}
	}

	public MatrizDisciplinar GetMatrizDisciplinar(long matrizDisciplinarUID)
	{
		try
		{
			return session.Get<MatrizDisciplinar>(matrizDisciplinarUID);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matriz disciplinar.", innerException);
		}
	}

	protected void SalveDivisoesDisciplinaresFracionamentoModificado(AlocacaoDisciplinar alocacaoDisciplinarPrincipal, TipoFracionamentoDisciplinar tipoFracionamentoDisciplinar, IList<DivisaoDisciplinar> divisoesDisciplinares, long servidorEditorUID, bool isCoordenador)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		alocacaoDisciplinarPrincipal.Fracionada = true;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Servidor servidor = null;
			using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
			{
				servidor = pessoaBO.GetServidor(servidorEditorUID);
			}
			if (servidor == null)
			{
				throw new Exception("Não foi encontrado servidor com o identificador informado.");
			}
			SalveAlocacaoDisciplinar(alocacaoDisciplinarPrincipal, horaPreparoPadrao: false, forcarSemestral: false);
			foreach (DivisaoDisciplinar divisoesDisciplinare in divisoesDisciplinares)
			{
				AlocacaoDisciplinar alocacaoDisciplinar = new AlocacaoDisciplinar();
				alocacaoDisciplinar.AlocacaoDisciplinarPrincipal = alocacaoDisciplinarPrincipal;
				alocacaoDisciplinar.MatrizDisciplinar = alocacaoDisciplinarPrincipal.MatrizDisciplinar;
				alocacaoDisciplinar.Ano = alocacaoDisciplinarPrincipal.Ano;
				alocacaoDisciplinar.Periodo = alocacaoDisciplinarPrincipal.Periodo;
				alocacaoDisciplinar.TipoAlocacaoDisciplinar = ((divisoesDisciplinare.TipoAlocacaoDisciplinar != null) ? divisoesDisciplinare.TipoAlocacaoDisciplinar : alocacaoDisciplinarPrincipal.TipoAlocacaoDisciplinar);
				alocacaoDisciplinar.CargaHoraria = divisoesDisciplinare.CargaHoraria / 2.5f * (float)alocacaoDisciplinarPrincipal.MatrizDisciplinar.MatrizCurricular.NumeroDeSemanas.Value;
				alocacaoDisciplinar.CoeficientePreparacaoAula = alocacaoDisciplinarPrincipal.CoeficientePreparacaoAula;
				alocacaoDisciplinar.Fracionada = false;
				alocacaoDisciplinar.TipoFracionamentoDisciplinar = tipoFracionamentoDisciplinar;
				alocacaoDisciplinar.Identificacao = divisoesDisciplinare.Identificacao;
				alocacaoDisciplinar.ServidorFracionador = servidor;
				alocacaoDisciplinar.IsCoordenadorFracionou = isCoordenador;
				SalveAlocacaoDisciplinar(alocacaoDisciplinar, horaPreparoPadrao: false, forcarSemestral: false);
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
			throw new Exception("Não foi possível salvar divisões para a alocação disciplinar.", innerException);
		}
	}

	protected void SalveDivisoesDisciplinares(AlocacaoDisciplinar alocacaoDisciplinarPrincipal, TipoFracionamentoDisciplinar tipoFracionamentoDisciplinar, IList<DivisaoDisciplinar> divisoesDisciplinares, long servidorEditorUID, bool isCoordenador)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		alocacaoDisciplinarPrincipal.Fracionada = true;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Servidor servidor = null;
			using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
			{
				servidor = pessoaBO.GetServidor(servidorEditorUID);
			}
			if (servidor == null)
			{
				throw new Exception("Não foi encontrado servidor com o identificador informado.");
			}
			SalveAlocacaoDisciplinar(alocacaoDisciplinarPrincipal, horaPreparoPadrao: false, forcarSemestral: false);
			foreach (DivisaoDisciplinar divisoesDisciplinare in divisoesDisciplinares)
			{
				AlocacaoDisciplinar alocacaoDisciplinar = new AlocacaoDisciplinar();
				alocacaoDisciplinar.AlocacaoDisciplinarPrincipal = alocacaoDisciplinarPrincipal;
				alocacaoDisciplinar.MatrizDisciplinar = alocacaoDisciplinarPrincipal.MatrizDisciplinar;
				alocacaoDisciplinar.Ano = alocacaoDisciplinarPrincipal.Ano;
				alocacaoDisciplinar.Periodo = alocacaoDisciplinarPrincipal.Periodo;
				alocacaoDisciplinar.TipoAlocacaoDisciplinar = ((divisoesDisciplinare.TipoAlocacaoDisciplinar != null) ? divisoesDisciplinare.TipoAlocacaoDisciplinar : alocacaoDisciplinarPrincipal.TipoAlocacaoDisciplinar);
				alocacaoDisciplinar.CargaHoraria = divisoesDisciplinare.CargaHoraria;
				alocacaoDisciplinar.CoeficientePreparacaoAula = alocacaoDisciplinarPrincipal.CoeficientePreparacaoAula;
				alocacaoDisciplinar.Fracionada = false;
				alocacaoDisciplinar.TipoFracionamentoDisciplinar = tipoFracionamentoDisciplinar;
				alocacaoDisciplinar.Identificacao = divisoesDisciplinare.Identificacao;
				alocacaoDisciplinar.ServidorFracionador = servidor;
				alocacaoDisciplinar.IsCoordenadorFracionou = isCoordenador;
				SalveAlocacaoDisciplinar(alocacaoDisciplinar, horaPreparoPadrao: false, forcarSemestral: false);
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
			throw new Exception("Não foi possível salvar divisões para a alocação disciplinar.", innerException);
		}
	}

	protected IList<MatrizDisciplinar> GetMatrizesDisciplinares(int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select md from MatrizDisciplinar md order by md.MatrizCurricular.Curso.Nome, md.MatrizCurricular.PeriodoInicialFuncionamento, md.Nome");
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<MatrizDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matrizes disciplinares.", innerException);
		}
	}

	protected IList<MatrizDisciplinar> GetMatrizesDisciplinares(long? codigoExterno)
	{
		try
		{
			IQuery query = session.CreateQuery("select md from MatrizDisciplinar md where md.CodigoExterno = :codigoExterno order by md.MatrizCurricular.Curso.Nome, md.MatrizCurricular.PeriodoInicialFuncionamento, md.Nome").SetParameter("codigoExterno", codigoExterno);
			return query.List<MatrizDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as matrizes disciplinares.", innerException);
		}
	}

	public int CountMatrizesDisciplinares()
	{
		try
		{
			IQuery query = session.CreateQuery("select count(md) from MatrizDisciplinar md");
			return query.UniqueResult<int>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar quantidade de matrizes disciplinares existentes.", innerException);
		}
	}

	public IList<AlocacaoDisciplinar> GetAlocacoesDisciplinares(int ano, short periodo, long? cursoUID, long? matrizCurricularUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (:cursoUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.CursoUID = :cursoUID)   and (:matrizCurricularUID is null or ad.MatrizDisciplinar.MatrizCurricular.MatrizCurricularUID = :matrizCurricularUID)   and ((ad.Fracionada = false and ad.MatrizDisciplinar.TipoDisciplinaUID not in (:listaTiposOrientacao) ) or (ad.Fracionada = true and ad.MatrizDisciplinar.TipoDisciplinaUID in (:listaTiposOrientacao))) order by ad.MatrizDisciplinar.MatrizCurricular.Curso.Nome, ad.MatrizDisciplinar.MatrizCurricular.PeriodoInicialFuncionamento, ad.MatrizDisciplinar.PeriodoRegularCurso, ad.MatrizDisciplinar.Nome").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("cursoUID", cursoUID)
				.SetParameter("matrizCurricularUID", matrizCurricularUID)
				.SetParameterList("listaTiposOrientacao", (from td in TipoDisciplina.GetInstances()
					where td.RequerOrientacao
					select td.TipoDisciplinaUID).ToArray());
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<AlocacaoDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar alocações disciplinares.", innerException);
		}
	}

	public IList<AlocacaoDisciplinar> GetAlocacoesDisciplinares(int ano, short? periodo, long servidorDocenteUID, int? nivelCursoUID, long? cursoUID, long? matrizCurricularUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad from AlocacaoDisciplinar ad where ad.Ano = :ano   and (:periodo is null or ad.Periodo = :periodo)   and ad.Fracionada = false   and ad.ServidorDocente.ServidorUID = :servidorDocenteUID   and (:nivelCursoUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.NivelCursoUID = :nivelCursoUID)   and (:cursoUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.CursoUID = :cursoUID)   and (:matrizCurricularUID is null or ad.MatrizDisciplinar.MatrizCurricular.MatrizCurricularUID = :matrizCurricularUID) order by ad.MatrizDisciplinar.MatrizCurricular.Curso.Nome, ad.MatrizDisciplinar.MatrizCurricular.PeriodoInicialFuncionamento, ad.MatrizDisciplinar.PeriodoRegularCurso, ad.MatrizDisciplinar.Nome").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("servidorDocenteUID", servidorDocenteUID)
				.SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameter("cursoUID", cursoUID)
				.SetParameter("matrizCurricularUID", matrizCurricularUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<AlocacaoDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar alocações disciplinares do docente.", innerException);
		}
	}

	public void AlocarDisciplina(long alocacaoDisciplinarUID, long servidorDocenteUID, int? quantidadeOrientandos, bool forcarSemestral)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarUID);
			if (alocacaoDisciplinar == null)
			{
				throw new Exception("Não foi encontrada alocação disciplinar com o identificador informado.");
			}
			if (alocacaoDisciplinar.ServidorDocente != null)
			{
				if (alocacaoDisciplinar.ServidorDocente.ServidorUID != servidorDocenteUID)
				{
					throw new Exception("A disciplina já encontra-se alocada por outro docente.");
				}
				return;
			}
			Servidor servidor = null;
			using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
			{
				servidor = pessoaBO.GetServidor(servidorDocenteUID);
			}
			if (servidor == null)
			{
				throw new Exception("Não foi encontrado servidor com o identificador informado.");
			}
			if (servidor.Cargo.TipoSiape != 2 && servidor.Cargo.TipoSiape != 3 && servidor.Cargo.CargoGrupoSiape != 702)
			{
				throw new Exception("O servidor não é um docente de ensino superior.");
			}
			if (alocacaoDisciplinar.MatrizDisciplinar.TipoDisciplina.RequerOrientacao)
			{
				AlocacaoDisciplinar alocacaoDisciplinar2 = alocacaoDisciplinar;
				alocacaoDisciplinar = new AlocacaoDisciplinar();
				alocacaoDisciplinar.AlocacaoDisciplinarPrincipal = alocacaoDisciplinar2;
				alocacaoDisciplinar.MatrizDisciplinar = alocacaoDisciplinar2.MatrizDisciplinar;
				alocacaoDisciplinar.Ano = alocacaoDisciplinar2.Ano;
				alocacaoDisciplinar.Periodo = alocacaoDisciplinar2.Periodo;
				alocacaoDisciplinar.TipoAlocacaoDisciplinar = alocacaoDisciplinar2.TipoAlocacaoDisciplinar;
				alocacaoDisciplinar.QuantidadeOrientandos = quantidadeOrientandos.Value;
				alocacaoDisciplinar.CargaHoraria = alocacaoDisciplinar2.CargaHoraria;
				alocacaoDisciplinar.CoeficientePreparacaoAula = alocacaoDisciplinar2.CoeficientePreparacaoAula;
				alocacaoDisciplinar.TipoFracionamentoDisciplinar = TipoFracionamentoDisciplinar.GetInstance(TipoFracionamentoDisciplinarEnum.ENCARGO_ORIENTACAO);
				alocacaoDisciplinar.Fracionada = false;
			}
			alocacaoDisciplinar.ServidorDocente = servidor;
			SalveAlocacaoDisciplinar(alocacaoDisciplinar, horaPreparoPadrao: false, forcarSemestral);
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
			throw new Exception("Não foi possível alocar disciplina para o docente.", innerException);
		}
	}

	public void DesalocarDisciplina(long alocacaoDisciplinarUID, long servidorDocenteUID)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		AlocacaoDisciplinar alocacaoDisciplinar = GetAlocacaoDisciplinar(alocacaoDisciplinarUID);
		if (alocacaoDisciplinar == null)
		{
			throw new Exception("Não foi encontrada alocação disciplinar com o identificador informado.");
		}
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			if (alocacaoDisciplinar.MatrizDisciplinar.TipoDisciplina.RequerOrientacao)
			{
				AlocacaoDisciplinar alocacaoDisciplinar2;
				try
				{
					alocacaoDisciplinar2 = (from ad in GetAlocacoesDisciplinares(alocacaoDisciplinar.Ano, alocacaoDisciplinar.Periodo, alocacaoDisciplinar.MatrizDisciplinar.MatrizDisciplinarUID)
						where !ad.Fracionada && ad.ServidorDocente.ServidorUID == servidorDocenteUID
						select ad).Single();
				}
				catch
				{
					alocacaoDisciplinar2 = null;
				}
				if (alocacaoDisciplinar2 != null)
				{
					session.Delete(alocacaoDisciplinar2);
				}
			}
			else
			{
				alocacaoDisciplinar.ServidorDocente = null;
				SalveAlocacaoDisciplinar(alocacaoDisciplinar, horaPreparoPadrao: false, forcarSemestral: false);
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
			throw new Exception("Não foi possível liberar alocação disciplinar.", innerException);
		}
	}

	public void SalveAlocacaoDisciplinar(AlocacaoDisciplinar alocacaoDisciplinar, bool horaPreparoPadrao, bool forcarSemestral)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			if (horaPreparoPadrao)
			{
				CalculeCargaHorariaSemanal(alocacaoDisciplinar, forcarSemestral);
			}
			else
			{
				CalculeCargaHorariaSemanal(alocacaoDisciplinar, forcarSemestral, alocacaoDisciplinar.CoeficientePreparacaoAula);
			}
			session.SaveOrUpdate(alocacaoDisciplinar);
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
			throw new Exception("Não foi possível salvar alocação disciplinar.", innerException);
		}
	}

	protected void CalculeCargaHorariaSemanal(AlocacaoDisciplinar alocacaoDisciplinar, bool forcarSemestral)
	{
		CalculeCargaHorariaSemanal(alocacaoDisciplinar, forcarSemestral, null);
	}

	protected void CalculeCargaHorariaSemanal(AlocacaoDisciplinar alocacaoDisciplinar, bool forcarSemestral, float? cargaHorariaPreparo)
	{
		using IEncargoBO encargoBO = BusinessFactory.GetInstance<IEncargoBO>();
		float num = (cargaHorariaPreparo.HasValue ? cargaHorariaPreparo.Value : encargoBO.CoeficientePreparacaoAula);
		if (alocacaoDisciplinar.TipoAlocacaoDisciplinar.RequerOrientacao)
		{
			alocacaoDisciplinar.CargaHorariaSemanal = encargoBO.GetCargaHorariaOrientacao(alocacaoDisciplinar.MatrizDisciplinar) * (float)(alocacaoDisciplinar.QuantidadeOrientandos.HasValue ? alocacaoDisciplinar.QuantidadeOrientandos.Value : 0);
			return;
		}
		float? num2 = alocacaoDisciplinar.MatrizDisciplinar.MatrizCurricular.NumeroDeSemanas;
		if (forcarSemestral)
		{
			if (!num2.HasValue)
			{
				num2 = 15f;
			}
			else if (PeriodicidadeCursoEnum.ANUAL.Equals(alocacaoDisciplinar.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade))
			{
				num2 /= 2f;
			}
		}
		else if (!num2.HasValue)
		{
			num2 = (PeriodicidadeCursoEnum.ANUAL.Equals(alocacaoDisciplinar.MatrizDisciplinar.MatrizCurricular.PeriodicidadeCurso.Periodicidade) ? 30f : 15f);
		}
		alocacaoDisciplinar.CargaHorariaSemanal = (num + 1f) * alocacaoDisciplinar.CargaHoraria / num2.Value;
		alocacaoDisciplinar.CoeficientePreparacaoAula = num;
	}

	public void RealocarDisciplinasDeOutroPeriodo(int ano, short periodo, IList<AlocacaoDisciplinar> alocacoes)
	{
		if (alocacoes.Count == 0)
		{
			throw new Exception("Lista de alocações vazia");
		}
		long matrizDisciplinarUID = alocacoes[0].MatrizDisciplinar.MatrizDisciplinarUID;
		foreach (AlocacaoDisciplinar alocaco in alocacoes)
		{
			if (alocaco.MatrizDisciplinar.MatrizDisciplinarUID != matrizDisciplinarUID)
			{
				throw new Exception("As alocações não fazem parte da mesma matriz disciplinar");
			}
		}
		AlocacaoDisciplinar alocacaoDisciplinar = null;
		foreach (AlocacaoDisciplinar alocaco2 in alocacoes)
		{
			if (alocaco2.AlocacaoDisciplinarPrincipal == null)
			{
				if (alocacaoDisciplinar != null)
				{
					throw new Exception("Na lista consta mais de uma alocação principal");
				}
				alocacaoDisciplinar = alocaco2;
			}
		}
		if (alocacaoDisciplinar == null)
		{
			throw new Exception("Na lista não consta uma alocação principal");
		}
		realocarDisciplinaPrincipalEPerpetuarFilhos(alocacoes, alocacaoDisciplinar, null, ano, periodo);
	}

	private void realocarDisciplinaPrincipalEPerpetuarFilhos(IList<AlocacaoDisciplinar> alocacoes, AlocacaoDisciplinar alocacaoCopia, AlocacaoDisciplinar alocacaoPai, int anoAtual, short periodoAtual)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			AlocacaoDisciplinar alocacaoDisciplinar = new AlocacaoDisciplinar();
			alocacaoDisciplinar.AlocacaoDisciplinarPrincipal = alocacaoPai;
			alocacaoDisciplinar.Ano = anoAtual;
			alocacaoDisciplinar.Periodo = periodoAtual;
			alocacaoDisciplinar.QuantidadeOrientandos = alocacaoCopia.QuantidadeOrientandos;
			alocacaoDisciplinar.ServidorDocente = null;
			alocacaoDisciplinar.TipoAlocacaoDisciplinar = alocacaoCopia.TipoAlocacaoDisciplinar;
			alocacaoDisciplinar.TipoAlocacaoDisciplinarUID = alocacaoCopia.TipoAlocacaoDisciplinarUID;
			alocacaoDisciplinar.TipoFracionamentoDisciplinar = alocacaoCopia.TipoFracionamentoDisciplinar;
			alocacaoDisciplinar.CargaHoraria = alocacaoCopia.CargaHoraria;
			alocacaoDisciplinar.CargaHorariaSemanal = alocacaoCopia.CargaHorariaSemanal;
			alocacaoDisciplinar.CoeficientePreparacaoAula = alocacaoCopia.CoeficientePreparacaoAula;
			alocacaoDisciplinar.Fracionada = alocacaoCopia.Fracionada;
			alocacaoDisciplinar.Identificacao = alocacaoCopia.Identificacao;
			alocacaoDisciplinar.JustificativaFracionamento = alocacaoCopia.JustificativaFracionamento;
			alocacaoDisciplinar.MatrizDisciplinar = alocacaoCopia.MatrizDisciplinar;
			session.SaveOrUpdate(alocacaoDisciplinar);
			foreach (AlocacaoDisciplinar alocaco in alocacoes)
			{
				if (alocaco.AlocacaoDisciplinarPrincipal != null && alocaco.AlocacaoDisciplinarPrincipal.AlocacaoDisciplinarUID == alocacaoCopia.AlocacaoDisciplinarUID)
				{
					realocarDisciplinaPrincipalEPerpetuarFilhos(alocacoes, alocaco, alocacaoDisciplinar, anoAtual, periodoAtual);
				}
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
			throw new Exception("Não foi possível salvar alocação disciplinar.", innerException);
		}
	}

	public AlocacaoDisciplinar GetAlocacaoDisciplinar(long alocacaoDisciplinarUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad from AlocacaoDisciplinar ad where ad.AlocacaoDisciplinarUID = :alocacaoDisciplinarUID").SetParameter("alocacaoDisciplinarUID", alocacaoDisciplinarUID);
			return query.UniqueResult<AlocacaoDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar alocação disciplinar através de seu identificador", innerException);
		}
	}

	public IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, int? campusUID, int? nivelCursoUID, long? unidadeOfertanteDisciplinaUID, int? firstRowIndex, int? maximumRows)
	{
		return GetCursosAlocacoesDisciplinares(ano, periodo, campusUID, nivelCursoUID, unidadeOfertanteDisciplinaUID, 1, firstRowIndex, maximumRows);
	}

	public IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, int? campusUID, int? nivelCursoUID, long? unidadeOfertanteDisciplinaUID, int formatoCursoUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct ad.MatrizDisciplinar.MatrizCurricular.Curso from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (:campusUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.NivelCursoUID = :nivelCursoUID)   and (ad.MatrizDisciplinar.MatrizCurricular.FormatoCursoUID = :formatoCursoUID)   and ((ad.Fracionada = false and ad.MatrizDisciplinar.TipoDisciplinaUID not in (:listaTiposOrientacao) ) or (ad.Fracionada = true and ad.MatrizDisciplinar.TipoDisciplinaUID in (:listaTiposOrientacao))) order by ad.MatrizDisciplinar.MatrizCurricular.Curso.Nome").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("campusUID", campusUID)
				.SetParameter("formatoCursoUID", formatoCursoUID)
				.SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameterList("listaTiposOrientacao", (from td in TipoDisciplina.GetInstances()
					where td.RequerOrientacao
					select td.TipoDisciplinaUID).ToArray());
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			new List<Curso>();
			return query.List<Curso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar cursos com alocações disciplinares para o período.", innerException);
		}
	}

	public IList<MatrizDisciplinar> GetMatrizesDisciplinaresAlocacoesDisciplinares(int ano, short periodo, long matrizCurricularUID, long unidadeOfertanteUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad.MatrizDisciplinar from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (ad.MatrizDisciplinar.MatrizCurricular.MatrizCurricularUID = :matrizCurricularUID)   and (ad.MatrizDisciplinar.UnidadeOfertante.UnidadeUID = :unidadeOfertanteUID)   and ad.AlocacaoDisciplinarPrincipal is null order by ad.MatrizDisciplinar.Nome").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("matrizCurricularUID", matrizCurricularUID)
				.SetParameter("unidadeOfertanteUID", unidadeOfertanteUID);
			return query.List<MatrizDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as matrizes disciplinares com alocações disciplinares para o período.", innerException);
		}
	}

	public IList<MatrizDisciplinar> GetMatrizesDisciplinaresAlocacoesDisciplinares(int ano, short periodo, long matrizCurricularUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad.MatrizDisciplinar from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (ad.MatrizDisciplinar.MatrizCurricular.MatrizCurricularUID = :matrizCurricularUID)   and ad.AlocacaoDisciplinarPrincipal is null order by ad.MatrizDisciplinar.Nome").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("matrizCurricularUID", matrizCurricularUID);
			return query.List<MatrizDisciplinar>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as matrizes disciplinares com alocações disciplinares para o período.", innerException);
		}
	}

	public IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, long unidadeOfertanteUID)
	{
		return GetCursosAlocacoesDisciplinares(ano, periodo, unidadeOfertanteUID, 1);
	}

	public IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, long unidadeOfertanteUID, int formatoCursoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct ad.MatrizDisciplinar.MatrizCurricular.Curso from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (ad.MatrizDisciplinar.UnidadeOfertante.UnidadeUID = :unidadeOfertanteUID)   and (ad.MatrizDisciplinar.MatrizCurricular.FormatoCursoUID = :formatoCursoUID)   and ((ad.Fracionada = false and ad.MatrizDisciplinar.TipoDisciplinaUID not in (:listaTiposOrientacao) ) or (ad.Fracionada = true and ad.MatrizDisciplinar.TipoDisciplinaUID in (:listaTiposOrientacao))) order by ad.MatrizDisciplinar.MatrizCurricular.Curso.Nome").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("unidadeOfertanteUID", unidadeOfertanteUID)
				.SetParameter("formatoCursoUID", formatoCursoUID)
				.SetParameterList("listaTiposOrientacao", (from td in TipoDisciplina.GetInstances()
					where td.RequerOrientacao
					select td.TipoDisciplinaUID).ToArray());
			return query.List<Curso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar cursos com alocações disciplinares para o período.", innerException);
		}
	}

	public IList<MatrizCurricular> GetMatrizesCurricularesAlocacoesDisciplinares(int ano, short periodo, int? campusUID, int? nivelCursoUID, long? cursoUID, long? unidadeOfertanteDisciplinaUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct ad.MatrizDisciplinar.MatrizCurricular from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (:campusUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.Campus.CampusUID = :campusUID)   and (:nivelCursoUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.NivelCursoUID = :nivelCursoUID)   and (:cursoUID is null or ad.MatrizDisciplinar.MatrizCurricular.Curso.CursoUID = :cursoUID)   and ((ad.Fracionada = false and ad.MatrizDisciplinar.TipoDisciplinaUID not in (:listaTiposOrientacao) ) or (ad.Fracionada = true and ad.MatrizDisciplinar.TipoDisciplinaUID in (:listaTiposOrientacao))) order by ad.MatrizDisciplinar.MatrizCurricular.PeriodoInicialFuncionamento").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("campusUID", campusUID)
				.SetParameter("nivelCursoUID", nivelCursoUID)
				.SetParameter("cursoUID", cursoUID)
				.SetParameterList("listaTiposOrientacao", (from td in TipoDisciplina.GetInstances()
					where td.RequerOrientacao
					select td.TipoDisciplinaUID).ToArray());
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<MatrizCurricular>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matrizes curriculares com alocações disciplinares para o período.", innerException);
		}
	}

	public IList<MatrizCurricular> GetMatrizesCurricularesAlocacoesDisciplinares(int ano, short periodo, long cursoUID, long unidadeOfertanteUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct ad.MatrizDisciplinar.MatrizCurricular from AlocacaoDisciplinar ad where ad.Ano = :ano and ad.Periodo = :periodo   and (ad.MatrizDisciplinar.MatrizCurricular.Curso.CursoUID = :cursoUID)   and (ad.MatrizDisciplinar.UnidadeOfertante.UnidadeUID = :unidadeOfertanteUID)   and ((ad.Fracionada = false and ad.MatrizDisciplinar.TipoDisciplinaUID not in (:listaTiposOrientacao) ) or (ad.Fracionada = true and ad.MatrizDisciplinar.TipoDisciplinaUID in (:listaTiposOrientacao))) order by ad.MatrizDisciplinar.MatrizCurricular.PeriodoInicialFuncionamento").SetParameter("ano", ano).SetParameter("periodo", periodo)
				.SetParameter("cursoUID", cursoUID)
				.SetParameter("unidadeOfertanteUID", unidadeOfertanteUID)
				.SetParameterList("listaTiposOrientacao", (from td in TipoDisciplina.GetInstances()
					where td.RequerOrientacao
					select td.TipoDisciplinaUID).ToArray());
			return query.List<MatrizCurricular>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar matrizes curriculares com alocações disciplinares para o período.", innerException);
		}
	}

	public void SalveMatrizDisciplinar(MatrizDisciplinar matrizDisciplinar)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(matrizDisciplinar);
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
			throw new Exception("Não foi possível salvar matriz disciplinar.", innerException);
		}
	}

	private CoordenadorCurso GetCoordenadorCurso(long cursoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select cc from CoordenadorCurso cc where (:cursoUID = cc.Curso.CursoUID)").SetParameter("cursoUID", cursoUID);
			return query.UniqueResult<CoordenadorCurso>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a coordenação.", innerException);
		}
	}

	public void DefinaUnidadeOfertanteMatrizDisciplinar(long matrizDisciplinarUID, long unidadeUID)
	{
		MatrizDisciplinar matrizDisciplinar = GetMatrizDisciplinar(matrizDisciplinarUID);
		if (matrizDisciplinar == null)
		{
			throw new Exception("Matriz Disciplinar com o identificador informado não foi encontrado.");
		}
		Unidade unidade = null;
		using (ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>())
		{
			unidade = localizacaoBO.GetUnidade(unidadeUID);
		}
		if (unidade == null)
		{
			throw new Exception("Unidade com o identificador informado não foi encontrada.");
		}
		if ((unidade.TipoUnidade & TipoUnidadeEnum.UNIDADE_LOTACIONAL_DOCENTE) == 0)
		{
			throw new Exception("Unidade com o identificador informado não é uma unidade lotacional de docentes.");
		}
		if (matrizDisciplinar.CodigoExterno.HasValue)
		{
			IList<MatrizDisciplinar> matrizesDisciplinares = GetMatrizesDisciplinares(matrizDisciplinar.CodigoExterno);
			foreach (MatrizDisciplinar item in matrizesDisciplinares)
			{
				if (item.UnidadeOfertante == null)
				{
					item.UnidadeOfertante = unidade;
					SalveMatrizDisciplinar(item);
				}
			}
		}
		matrizDisciplinar.UnidadeOfertante = unidade;
		SalveMatrizDisciplinar(matrizDisciplinar);
	}

	public void DefinaUnidadeOfertanteCurso(long cursoUID, long unidadeUID)
	{
		Curso curso = GetCurso(cursoUID);
		if (curso == null)
		{
			throw new Exception("Curso com o identificador informado não foi encontrado.");
		}
		Unidade unidade = null;
		using (ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>())
		{
			unidade = localizacaoBO.GetUnidade(unidadeUID);
		}
		if (unidade == null)
		{
			throw new Exception("Unidade com o identificador informado não foi encontrada.");
		}
		if ((unidade.TipoUnidade & (TipoUnidadeEnum)0x18) == 0)
		{
			throw new Exception($"A unidade ofertante de curso deve ser {TipoUnidadeEnum.COORDENACAO_ENSINO_GRADUACAO.Descricao()} ou {TipoUnidadeEnum.COORDENACAO_ENSINO_POS_GRADUACAO.Descricao()}");
		}
		curso.UnidadeOfertante = unidade;
		SalveCurso(curso);
	}

	public void RemovaUnidadeOfertanteCurso(long cursoUID)
	{
		Curso curso = GetCurso(cursoUID);
		curso.UnidadeOfertante = null;
		SalveCurso(curso);
	}

	public void SalveCurso(Curso curso)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(curso);
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
			throw new Exception("Não foi possível salvar curso.", innerException);
		}
	}

	public PlanoPedagogico getPlanoPedagogico(long matrizCurricularUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select pp from PlanoPedagogico pp where (:matrizCurricularUID = pp.MatrizCurricular.MatrizCurricularUID)").SetParameter("matrizCurricularUID", matrizCurricularUID);
			return query.UniqueResult<PlanoPedagogico>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o plano pedagógico.", innerException);
		}
	}

	public void cadastrarPlanoPedagogico(long matrizCurricularUID, string nomeArquivo, string tipoConteudo, byte[] arquivo, DateTime dataModificacao)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			MatrizCurricular matrizCurricular = GetMatrizCurricular(matrizCurricularUID);
			if (matrizCurricular == null)
			{
				throw new Exception("Não foi encontrada a matriz curricular com o identificador informado.");
			}
			PlanoPedagogico planoPedagogico = getPlanoPedagogico(matrizCurricularUID);
			if (planoPedagogico == null)
			{
				planoPedagogico = new PlanoPedagogico();
			}
			planoPedagogico.MatrizCurricular = matrizCurricular;
			planoPedagogico.NomeArquivo = nomeArquivo;
			planoPedagogico.TipoConteudo = tipoConteudo;
			planoPedagogico.Arquivo = arquivo;
			planoPedagogico.DataModificacao = dataModificacao;
			session.SaveOrUpdate(planoPedagogico);
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
			throw new Exception("Não foi possível cadastrar o plano pedagógico.", innerException);
		}
	}

	public IList<TipoTecnologiaAssistiva> getTiposTecnologiaAssistiva()
	{
		IQuery query = session.CreateQuery("select tta from TipoTecnologiaAssistiva tta");
		return query.List<TipoTecnologiaAssistiva>();
	}

	public IList<TecnologiaAssistiva> getTecnologiasAssistivas(long cursoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ta from TecnologiaAssistiva ta where ta.Curso.CursoUID = :cursoUID").SetParameter("cursoUID", cursoUID);
			return query.List<TecnologiaAssistiva>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as tecnologias assistivas do curso.", innerException);
		}
	}

	private TipoTecnologiaAssistiva getTipoTecnologiaAssistiva(string tipoTecnologiaAssistivaUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select tta from TipoTecnologiaAssistiva tta where tta.TipoTecnologiaAssistivaUID = :tipoTecnologiaAssistivaUID").SetParameter("tipoTecnologiaAssistivaUID", tipoTecnologiaAssistivaUID);
			return query.UniqueResult<TipoTecnologiaAssistiva>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o tipo de tecnologia assistiva.", innerException);
		}
	}

	public void cadastrarTecnologiaAssistiva(long cursoUID, string tipoTecnologiaAssistivaUID)
	{
		Curso curso = GetCurso(cursoUID);
		if (curso == null)
		{
			throw new Exception("Não foi possível recuperar o curso com a identificação informada para cadastrar uma tecnologia assistiva.");
		}
		TipoTecnologiaAssistiva tipoTecnologiaAssistiva = getTipoTecnologiaAssistiva(tipoTecnologiaAssistivaUID);
		if (tipoTecnologiaAssistiva == null)
		{
			throw new Exception("Não foi possível recuperar o tipo de tecnologia assistiva com a identificação informada para cadastrar uma tecnologia assistiva.");
		}
		TecnologiaAssistiva tecnologiaAssistiva = getTecnologiaAssistiva(curso.CursoUID, tipoTecnologiaAssistiva.TipoTecnologiaAssistivaUID);
		if (tecnologiaAssistiva != null)
		{
			return;
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			tecnologiaAssistiva = new TecnologiaAssistiva();
			tecnologiaAssistiva.Curso = curso;
			tecnologiaAssistiva.TipoTecnologiaAssistiva = tipoTecnologiaAssistiva;
			session.SaveOrUpdate(tecnologiaAssistiva);
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
			throw new Exception("Não foi possível cadastrar a tecnologia assistiva do curso.", innerException);
		}
	}

	private TecnologiaAssistiva getTecnologiaAssistiva(long cursoUID, string tipoTecnologiaAssistivaUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ta from TecnologiaAssistiva ta where ta.Curso.CursoUID = :cursoUID and ta.TipoTecnologiaAssistiva.TipoTecnologiaAssistivaUID = :tipoTecnologiaAssistivaUID").SetParameter("cursoUID", cursoUID).SetParameter("tipoTecnologiaAssistivaUID", tipoTecnologiaAssistivaUID);
			return query.UniqueResult<TecnologiaAssistiva>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a tecnologia assistiva.", innerException);
		}
	}

	public void removerTecnologiaAssistiva(long cursoUID, string tipoTecnologiaAssistivaUID)
	{
		TecnologiaAssistiva tecnologiaAssistiva = getTecnologiaAssistiva(cursoUID, tipoTecnologiaAssistivaUID);
		if (tecnologiaAssistiva == null)
		{
			return;
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.Delete(tecnologiaAssistiva);
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
			throw new Exception("Não foi possível remover a tecnologia assistiva.", innerException);
		}
	}
}

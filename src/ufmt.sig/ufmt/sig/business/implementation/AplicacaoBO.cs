using System;
using System.Collections.Generic;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;

namespace ufmt.sig.business.implementation;

public class AplicacaoBO : IAplicacaoBO, IDisposable
{
	private ISession session;

	internal AplicacaoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public Aplicacao getAplicacao(long aplicacaoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ad from Aplicacao ad where ad.AplicacaoUID = :aplicacaoUID").SetParameter("aplicacaoUID", aplicacaoUID);
			return query.UniqueResult<Aplicacao>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a aplicação através de sua ID.", innerException);
		}
	}

	public IList<Aplicacao> getAplicacoes(string situacao, string sigla, string nome, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct app from Aplicacao app where (:nome is null or ilike(app.Nome, :nome))   and (:sigla is null or ilike(app.Sigla, :sigla))   and (:situacao is null or app.Situacao = :situacao)").SetParameter("nome", nome).SetParameter("sigla", sigla)
				.SetParameter("situacao", situacao);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Aplicacao>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as aplicações.", innerException);
		}
	}

	public void salvaAplicacao(Aplicacao app)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(app);
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
			throw new Exception("Não foi possível salvar a aplicação.", innerException);
		}
	}
}

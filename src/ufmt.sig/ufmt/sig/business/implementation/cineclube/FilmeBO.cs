using System;
using System.Collections.Generic;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.business.cineclube;
using ufmt.sig.entity.cineclube;

namespace ufmt.sig.business.implementation.cineclube;

public class FilmeBO : IFilmeBO, IDisposable
{
	private ISession session;

	internal FilmeBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public Filme getFilme(long filmeUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select fi from ufmt.sig.entity.cineclube.Filme fi where fi.FilmeUID = :filmeUID").SetParameter("filmeUID", filmeUID);
			return query.UniqueResult<Filme>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o filme através de sua ID.", innerException);
		}
	}

	public IList<Filme> getFilmes(long? generoUID, string titulo, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select fi from ufmt.sig.entity.cineclube.Filme fi  where (:genero is null or fi.Genero.GeneroUID = :genero) and (:titulo is null or ilike(fi.Titulo, :titulo))").SetParameter("genero", generoUID).SetParameter("titulo", titulo);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Filme>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o acervo.", innerException);
		}
	}

	public IList<Agenda> getAgenda(DateTime DataInicial, DateTime DataFinal, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select ag from ufmt.sig.entity.cineclube.Agenda ag where ag.Data >= :DataInicial and ag.Data <= :DataFinal").SetParameter("DataInicial", DataInicial).SetParameter("DataFinal", DataFinal);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Agenda>();
		}
		catch
		{
			throw new Exception("Não foi possível recuperar a agenda deste filme.");
		}
	}

	public IList<Agenda> getAgendas(long filmeUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ag from ufmt.sig.entity.cineclube.Agenda ag where ag.Filme.FilmeUID = :filmeUID").SetParameter("filmeUID", filmeUID);
			return query.List<Agenda>();
		}
		catch
		{
			throw new Exception("Não foi possível recuperar as agendas deste filme.");
		}
	}

	public Agenda getAgenda(int agendaUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ag from ufmt.sig.entity.cineclube.Agenda ag where ag.AgendaUID = :agendaUID").SetParameter("agendaUID", agendaUID);
			return query.UniqueResult<Agenda>();
		}
		catch
		{
			throw new Exception("Não foi possível recuperar a agenda selecionada.");
		}
	}

	public Genero getGenero(long generoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ge from ufmt.sig.entity.cineclube.Genero ge where ge.GeneroUID = :generoUID").SetParameter("generoUID", generoUID);
			return query.UniqueResult<Genero>();
		}
		catch
		{
			throw new Exception("Não foi possível recuperar o gênero deste filme.");
		}
	}

	public IList<Genero> getGeneros(int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select ge from ufmt.sig.entity.cineclube.Genero ge");
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Genero>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar uma lista de gêneros.", innerException);
		}
	}

	public void salvarAgenda(Agenda ag)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(ag);
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
			throw new Exception("Não foi possível salvar a agenda do filme.", innerException);
		}
	}

	public void salvarGenero(Genero genero)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(genero);
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
			throw new Exception("Não foi possível salvar o gênero do filme.", innerException);
		}
	}

	public void salvarFilme(Filme filme)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(filme);
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
			throw new Exception("Não foi possível salvar o filme.", innerException);
		}
	}

	public void removeAgenda(Agenda agenda)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.Delete(agenda);
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
			throw new Exception("Não foi possível remover a agenda do filme.", innerException);
		}
	}

	public void removeFilme(Filme filme)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.Delete(filme);
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
			throw new Exception("Não foi possível remover o filme.", innerException);
		}
	}
}

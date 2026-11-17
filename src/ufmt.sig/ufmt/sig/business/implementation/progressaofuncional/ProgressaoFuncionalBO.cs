using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Hql.Ast.ANTLR;
using ufmt.nhibernate;
using ufmt.sig.business.progressaofuncional;
using ufmt.sig.entity.progressaofuncional;

namespace ufmt.sig.business.implementation.progressaofuncional;

public class ProgressaoFuncionalBO : IProgressaoFuncionalBO, IDisposable
{
	private ISession session;

	public ProgressaoFuncionalBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public List<T> SelecionarTodos<T>() where T : IEntidade
	{
		IQuery query = null;
		try
		{
			query = session.CreateQuery("from " + typeof(T).ToString() + " c ");
		}
		catch (QuerySyntaxException ex)
		{
			throw ex;
		}
		return query.List<T>().ToList();
	}

	public List<ProgressaoFuncional> SelecionarProgressaoFuncionalPorPessoaUID(long pessoaUID)
	{
		IQuery query = null;
		try
		{
			query = session.CreateQuery("from " + typeof(ProgressaoFuncional).ToString() + " c where c.Pessoa.PessoaUID=:pessoaUID").SetParameter("pessoaUID", pessoaUID);
		}
		catch (QuerySyntaxException ex)
		{
			throw ex;
		}
		return query.List<ProgressaoFuncional>().ToList();
	}

	public void Deletar<T>(int cod) where T : IEntidade
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			List<T> source = SelecionarTodos<T>();
			T val = source.FirstOrDefault((T el) => el.Id.Equals(cod));
			if (val != null)
			{
				session.Delete(val);
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
			throw new Exception("Não foi possível Deletar.", innerException);
		}
	}

	public int Inserir(object obj)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.Save(obj);
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
			throw new Exception("Não foi possível Inserir.", innerException);
		}
		return 0;
	}

	public int Atualizar(object obj)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!transaction.IsActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(obj);
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
			throw new Exception("Não foi possível Atualizar.", innerException);
		}
		return 0;
	}
}

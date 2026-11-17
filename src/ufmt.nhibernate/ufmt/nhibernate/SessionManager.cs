using System;
using System.Configuration;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect.Function;
using ufmt.nhibernate.configuration;

namespace ufmt.nhibernate;

public sealed class SessionManager
{
	private const string CurrentSessionKey = "__ufmt_nhibernate_SessionManager_CurrentSessionKey__";

	private const string CurrentSessionHoldersKey = "__ufmt_nhibernate_SessionManager_CurrentSessionHoldersKey__";

	private static readonly ISessionFactory sessionFactory;

	static SessionManager()
	{
		NHibernateConfigSection nHibernateConfigSection = (NHibernateConfigSection)ConfigurationManager.GetSection("NHibernateConfigSection");
		if (nHibernateConfigSection == null)
		{
			throw new Exception("A utilização de SessionManager depende da definição da seção NHibernateConfigSection no arquivo de configuração da aplicação.");
		}
		ConnectionStringSettings val = ConfigurationManager.ConnectionStrings[nHibernateConfigSection.ConnectionStringName];
		if (val == null)
		{
			throw new Exception("A conexão com o banco de dados não foi definida corretamente.");
		}
		NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
		configuration.SetProperty("dialect", nHibernateConfigSection.Dialect);
		configuration.SetProperty("connection.connection_string", val.ConnectionString);
		configuration.SetProperty("connection.provider", nHibernateConfigSection.ConnectionProvider);
		configuration.SetProperty("proxyfactory.factory_class", nHibernateConfigSection.ProxyFactoryClass);
		configuration.AddAssembly(nHibernateConfigSection.AssemblyMappingFiles);
		configuration.AddSqlFunction("count", new ClassicCountFunction());
		sessionFactory = configuration.BuildSessionFactory();
	}

	public static ISession GetSession()
	{
		HttpContext current = HttpContext.Current;
		if (current == null)
		{
			throw new NotSupportedException("SessionManager suportado apenas em contexto HTTP.");
		}
		ISession session = null;
		int? num = null;
		session = current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionKey__"] as ISession;
		num = current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionHoldersKey__"] as int?;
		if (session == null)
		{
			session = sessionFactory.OpenSession();
			current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionKey__"] = session;
		}
		num = ((!num.HasValue) ? 1 : (num.Value + 1));
		current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionHoldersKey__"] = num;
		return session;
	}

	public static void CloseSession()
	{
		HttpContext current = HttpContext.Current;
		if (current == null)
		{
			throw new NotSupportedException("SessionManager suportado apenas em contexto HTTP.");
		}
		int? num = current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionHoldersKey__"] as int?;
		ISession session = current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionKey__"] as ISession;
		num = (num.HasValue ? (num.Value - 1) : 0);
		if (num.Value <= 0 && session != null)
		{
			session.Close();
			current.Session.Remove("__ufmt_nhibernate_SessionManager_CurrentSessionKey__");
		}
		current.Session["__ufmt_nhibernate_SessionManager_CurrentSessionHoldersKey__"] = num;
	}
}

using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace ufmt.nhibernate.dialect;

public class CustomMsSql2008Dialect : MsSql2008Dialect
{
	public CustomMsSql2008Dialect()
	{
		RegisterILike();
	}

	private void RegisterILike()
	{
		RegisterFunction("ilike", new SQLFunctionTemplate(NHibernateUtil.String, "?1 like ?2 collate SQL_Latin1_General_CP850_CI_AI"));
	}
}

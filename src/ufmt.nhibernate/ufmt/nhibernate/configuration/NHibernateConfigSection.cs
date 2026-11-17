using System;
using System.Configuration;

namespace ufmt.nhibernate.configuration;

public sealed class NHibernateConfigSection : ConfigurationSection
{
	private static ConfigurationPropertyCollection properties;

	private static readonly ConfigurationProperty connectionStringName = new ConfigurationProperty("connectionStringName", typeof(string), (object)null, (ConfigurationPropertyOptions)2);

	private static readonly ConfigurationProperty dialect = new ConfigurationProperty("dialect", typeof(string), (object)null, (ConfigurationPropertyOptions)2);

	private static readonly ConfigurationProperty assemblyMappingFiles = new ConfigurationProperty("assemblyMappingFiles", typeof(string), (object)null, (ConfigurationPropertyOptions)2);

	private static readonly ConfigurationProperty connectionProvider = new ConfigurationProperty("connectionProvider", typeof(string), (object)"NHibernate.Connection.DriverConnectionProvider", (ConfigurationPropertyOptions)1);

	private static readonly ConfigurationProperty proxyFactoryClass = new ConfigurationProperty("proxyFactoryClass", typeof(string), (object)"NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle", (ConfigurationPropertyOptions)1);

	protected override ConfigurationPropertyCollection Properties => properties;

	public string ConnectionStringName
	{
		get
		{
			string text = (string)this["connectionStringName"];
			if (string.IsNullOrEmpty(text))
			{
				throw new ApplicationException("A propriedade connectionStringName da seção NHibernateConfigSection não foi definida corretamente.");
			}
			return text;
		}
	}

	public string Dialect
	{
		get
		{
			string text = (string)this["dialect"];
			if (string.IsNullOrEmpty(text))
			{
				throw new ApplicationException("A propriedade dialect da seção NHibernateConfigSection não foi definida corretamente.");
			}
			return text;
		}
	}

	public string AssemblyMappingFiles
	{
		get
		{
			string text = (string)this["assemblyMappingFiles"];
			if (string.IsNullOrEmpty(text))
			{
				throw new ApplicationException("A propriedade assemblyMappingFiles da seção NHibernateConfigSection não foi definida corretamente.");
			}
			return text;
		}
	}

	public string ConnectionProvider => (string)this["connectionProvider"];

	public string ProxyFactoryClass => (string)this["proxyFactoryClass"];

	public NHibernateConfigSection()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Obj, but got Unknown
		properties = new ConfigurationPropertyCollection();
		properties.Add(connectionStringName);
		properties.Add(dialect);
		properties.Add(assemblyMappingFiles);
		properties.Add(connectionProvider);
		properties.Add(proxyFactoryClass);
	}

	static NHibernateConfigSection()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
	}
}

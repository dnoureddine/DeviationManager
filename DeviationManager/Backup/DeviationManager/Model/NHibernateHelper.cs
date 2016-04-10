using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)

                InitializeSessionFactory();
            return _sessionFactory;
        }
    }

    private static void InitializeSessionFactory()
    {
        _sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008
              .ConnectionString(
              @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\noureddine\documents\visual studio 2013\Projects\TaskManager\task\taskDB.mdf;
		      Integrated Security=True") // Modify your ConnectionString
                          .ShowSql()
            )
            .Mappings(m =>
                      m.FluentMappings
                          .AddFromAssemblyOf<CustomerMap>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                            .Create(true, true))
            .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}
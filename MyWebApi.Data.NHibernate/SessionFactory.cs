using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MyWebApi.Data.NHibernate.DatabaseMapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MyWebApi.Data.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory session;
        private const string HOST = "localhost";
        private const string USER = "root";
        private const string PASSWORD = "";
        private const string DB = "nh_db";

        public static ISessionFactory CreateSessionFactory()
        {
            FluentConfiguration _config = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(
                                                                       x => x.Server(HOST).
                                                                          Username(USER).
                                                                          Password(PASSWORD).
                                                                          Database(DB)
                                                                        ))
                                                                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
                                                                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            session = _config.BuildSessionFactory();
            return session;
        }

        /** open a session to make transactions */
        public static ISession OpenSession()
        {
            return CreateSessionFactory().OpenSession();
        }
    }
}

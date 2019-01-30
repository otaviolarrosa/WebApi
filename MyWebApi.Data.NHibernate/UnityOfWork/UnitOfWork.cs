using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using MyWebApi.Data.NHibernate.DatabaseMapping;
using MyWebApi.Interface.Data.NHibernate;
using MyWebApi.Ioc;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MyWebApi.Data.NHibernate.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            IConfigurationSection settings = ServiceLocator.Current.GetInstance<IConfiguration>().GetSection("MySqlDatabase");
            string host = settings.GetSection("Host").Value;
            string user = settings.GetSection("User").Value;
            string databaseName = settings.GetSection("DatabaseName").Value;
            string password = settings.GetSection("Password").Value;

            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the 
            // application lifetime - the first time the UnitOfWork class is used
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(
                                                                       x => x.Server(host).
                                                                          Username(user).
                                                                          Password(password).
                                                                          Database(databaseName)
                                                                        ))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Commit();
                }
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Rollback();
                }

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Rollback();
                }
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}

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

        private static string CONNECTION_STRING;

        static UnitOfWork()
        {
            IConfigurationSection connStringSection = ServiceLocator.Current.GetInstance<IConfiguration>().GetSection("ConnectionStrings");
            CONNECTION_STRING = connStringSection.GetSection("MySqlConnectionString").Value;
            _sessionFactory = Fluently.Configure()
               .Database(MySQLConfiguration.Standard.ConnectionString(CONNECTION_STRING))
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

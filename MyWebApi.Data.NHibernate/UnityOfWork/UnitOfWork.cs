using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MyWebApi.Data.NHibernate.DatabaseMapping;
using MyWebApi.Interface.Data.NHibernate;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MyWebApi.Data.NHibernate.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private const string HOST = "localhost";
        private const string USER = "root";
        private const string PASSWORD = "";
        private const string DB = "nh_db";

        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the 
            // application lifetime - the first time the UnitOfWork class is used
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(
                                                                       x => x.Server(HOST).
                                                                          Username(USER).
                                                                          Password(PASSWORD).
                                                                          Database(DB)
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

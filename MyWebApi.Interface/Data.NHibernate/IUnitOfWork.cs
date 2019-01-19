namespace MyWebApi.Interface.Data.NHibernate
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}

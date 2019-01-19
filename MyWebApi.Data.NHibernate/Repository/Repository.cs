using System.Linq;
using MyWebApi.Data.NHibernate.UnityOfWork;
using MyWebApi.Interface.Data.NHibernate;
using MyWebApi.Mapping.Entities;
using NHibernate;

namespace MyWebApi.Data.NHibernate.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ISession Session { get { return _unitOfWork.Session; } }

        private UnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }
        
        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}

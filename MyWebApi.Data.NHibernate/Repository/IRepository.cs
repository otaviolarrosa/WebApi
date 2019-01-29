using MyWebApi.Mapping.Entities;
using System.Linq;

namespace MyWebApi.Data.NHibernate.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

using MyWebApi.Mapping.Entities;
using MyWebApi.Utility.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Data.NHibernate.Repository
{
    public class RepositoryFake<T> : IRepository<T> where T : Entity
    {
        private List<T> _data;

        public RepositoryFake()
        {
            _data = new List<T>();
        }

        public int Create(T entity)
        {
            if (entity.Id.IsNullOrZero())
                entity.Id = _data.Any() ? _data.Max(x => x.Id) + 1 : 1;

            _data.Add(entity);
            return entity.Id;
        }
        public void Delete(int id)
        {
            _data.RemoveAll(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _data.AsQueryable();
        }

        public T GetById(int id)
        {
            return _data.FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            T entityToUpdate = _data.FirstOrDefault(x => x.Id == entity.Id);
            _data.Remove(entity);
            _data.Add(entity);
        }
    }
}

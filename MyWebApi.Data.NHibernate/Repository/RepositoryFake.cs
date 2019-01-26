using MyWebApi.Mapping.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Data.NHibernate.Repository
{
    public class RepositoryFake<T> : IRepository<T> where T : Entity
    {
        private List<T> _data;

        public RepositoryFake() => _data = new List<T>();

        public void Create(T entity) => _data.Add(entity);

        public void Delete(int id) => _data.RemoveAll(x => x.Id == id);

        public IQueryable<T> GetAll() => _data.AsQueryable();

        public T GetById(int id) => _data.FirstOrDefault(x => x.Id == id);

        public void Update(T entity)
        {
            var entityToUpdate = _data.FirstOrDefault(x => x.Id == entity.Id);
            _data.Remove(entity);
            _data.Add(entity);
        }
    }
}

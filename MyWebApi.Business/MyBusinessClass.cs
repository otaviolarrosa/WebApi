using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Interface.Product;
using MyWebApi.Ioc;
using MyWebApi.Mapping.Entities;

namespace MyWebApi.Business
{
    public class MyBusinessClass : IMyBusinessClass
    {
        private readonly IRepository<Product> _repository;

        public MyBusinessClass(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void MyBusinessMethod()
        {
            _repository.Create(new Product { Name = "Product From Constructor" });
            ServiceLocator.Current.GetInstance<IRepository<Product>>().Create(new Product { Name = "Product From ServiceLocator" });
        }
    }
}

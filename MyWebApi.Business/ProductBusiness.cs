using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Interface.Product;
using MyWebApi.Ioc;
using MyWebApi.Mapping.Entities;
using MyWebApi.Models.Product;
using MyWebApi.Utility.ExtensionMethods;
using System.Threading.Tasks;

namespace MyWebApi.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IRepository<Product> _repository;

        public ProductBusiness(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<ProductModel> InsertNewProduct(ProductModel product)
        {
            Product entityProduct = new Product { Name = product.Name };
            int id = ServiceLocator.Current.GetInstance<IRepository<Product>>().Create(entityProduct);
            return new ProductModel(id, entityProduct.Name);
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            Product entityProduct = ServiceLocator.Current.GetInstance<IRepository<Product>>().GetById(id);
            return entityProduct.IsNull() ? null : new ProductModel(entityProduct.Id, entityProduct.Name);
        }
    }
}

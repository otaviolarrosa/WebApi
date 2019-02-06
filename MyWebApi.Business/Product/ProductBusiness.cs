using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Interface.Product;
using MyWebApi.Ioc;
using MyWebApi.Models.Product;
using MyWebApi.Utility.ExtensionMethods;
using System.Threading.Tasks;
using System.Transactions;
using EntityProduct = MyWebApi.Mapping.Entities.Product;

namespace MyWebApi.Business.Product
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IRepository<EntityProduct> _repository;

        public ProductBusiness(IRepository<EntityProduct> repository)
        {
            _repository = repository;
        }

        public async Task<ProductModel> InsertNewProduct(ProductModel product)
        {
            EntityProduct entityProduct = new EntityProduct
            {
                Name = product.Name,
                Department = new Mapping.Entities.Department { Id = product.DepartmentId ?? 0 }
            };

            using (TransactionScope scope = new TransactionScope())
            {
                int id = ServiceLocator.Current.GetInstance<IRepository<EntityProduct>>().Create(entityProduct);
                scope.Complete();
                return new ProductModel(id, entityProduct.Name, entityProduct.DepartmentId);
            }
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            EntityProduct entityProduct = ServiceLocator.Current.GetInstance<IRepository<EntityProduct>>().GetById(id);
            return entityProduct.IsNull() ? null : new ProductModel(entityProduct.Id, entityProduct.Name, entityProduct.DepartmentId);
        }
    }
}

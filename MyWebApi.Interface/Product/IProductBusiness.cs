using MyWebApi.Models.Product;
using System.Threading.Tasks;

namespace MyWebApi.Interface.Product
{
    public interface IProductBusiness
    {
        Task<ProductModel> InsertNewProduct(ProductModel product);
        Task<ProductModel> GetProductById(int id);
    }
}

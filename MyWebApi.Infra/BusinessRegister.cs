using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Business.Department;
using MyWebApi.Business.Product;
using MyWebApi.Interface.Department;
using MyWebApi.Interface.Product;

namespace MyWebApi.Infra
{
    public class BusinessRegister
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IProductBusiness, ProductBusiness>();
            services.AddTransient<IDepartmentBusiness, DepartmentBusiness>();
        }
    }
}

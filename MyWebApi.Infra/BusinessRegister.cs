using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Business;
using MyWebApi.Interface.Product;

namespace MyWebApi.Infra
{
    public class BusinessRegister
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IMyBusinessClass, MyBusinessClass>();
        }
    }
}

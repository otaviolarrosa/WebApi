using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Mapping.Entities;

namespace MyWebApi.Infra
{
    public class DataRegisterFake
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Product>, RepositoryFake<Product>>();
            services.AddSingleton<IRepository<Department>, RepositoryFake<Department>>();
        }
    }
}

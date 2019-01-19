using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Data.NHibernate.UnityOfWork;
using MyWebApi.Interface.Data.NHibernate;
using MyWebApi.Mapping.Entities;

namespace MyWebApi.Infra
{
    public class DataRegister
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Product>, Repository<Product>>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Infra;

namespace MyWebApi.Infra
{
    public class RegisterClass
    {
        public void Register(IServiceCollection services)
        {
            new BusinessRegister().Register(services);
            new DataRegister().Register(services);
        }
    }
}

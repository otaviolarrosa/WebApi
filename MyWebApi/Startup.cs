using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyWebApi.Infra;
using MyWebApi.Ioc;
using Swashbuckle.AspNetCore.Swagger;

namespace MyWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "My Microservice Api",
                        Version = "v1",
                        Description = "Projeto de demonstração ASP.Net Core",
                        Contact = new Contact
                        {
                            Name = "Otávio Larrosa",
                            Url = "https://github.com/otaviolarrosa"
                        }
                    });
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq();
            });
            new RegisterClass().Register(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Microservice Api");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

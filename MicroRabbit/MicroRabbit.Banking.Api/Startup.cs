using MicroRabbit.Infra.IoC;
using MicroRabbit.Ranking.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MicroRabbit.Banking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add iServices to the container.
        public void ConfigureServices(IServiceCollection iServices)
        {
            iServices.AddDbContext<BankingDbContext>
            (
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("BankingDbConnection"));
                }
             );
             iServices.AddControllers();

            iServices.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Banking Microservices", Version = "v1" });

            });

            iServices.AddMediatR(typeof(Startup));
            
            //Added this to register iServices
            RegisterServices(iServices);
        }

        private void RegisterServices(IServiceCollection iServices)
        {
            //Call the RegisterServices in the DependencyContainer to register the iServices
            DependencyContainer.RegisterServices(iServices);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder iApp, IWebHostEnvironment iWebHostEnv)
        {
            if (iWebHostEnv.IsDevelopment())
            {
                iApp.UseDeveloperExceptionPage();
            }


            iApp.UseHttpsRedirection();
            iApp.UseSwagger();
            iApp.UseSwaggerUI
            (c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice v1");
                } 
            );
            
            iApp.UseRouting();

            iApp.UseAuthorization();

            iApp.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

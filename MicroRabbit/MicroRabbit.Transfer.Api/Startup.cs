using MicroRabbit.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using MediatR;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventHandlers;

namespace MicroRabbit.Transfer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection iServices)
        {
            //----------------------------
            iServices.AddDbContext<TransferDbContext>
            (
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("TransferDbConnection"));
                }
             );
            iServices.AddControllers();

            iServices.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Transfer Microservices", Version = "v1" });

            });

            iServices.AddMediatR(typeof(Startup));

            //Added this to register iServices
            RegisterServices(iServices);
        
            // ---------------------------

            iServices.AddControllers();
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice v1");
                }
            );

            iApp.UseRouting();

            iApp.UseAuthorization();

            iApp.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Configure to consume events
            ConfigureEventBus(iApp);
        }

        private void ConfigureEventBus(IApplicationBuilder iApp)
        {
            var eventBus = iApp.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
        }
    }

    internal class Info : OpenApiInfo
    {
        // Commented out to use the members from the based class OpenApiInfo
        //public string Title { get; set; }
        //public string Version { get; set; }
    }
}

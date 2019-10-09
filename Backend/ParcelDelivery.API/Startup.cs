using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ParcelDelivery.Domain.Repositories;
using ParcelDelivery.Domain.Services;
using ParcelDelivery.Infrastructure.Repositories;
using ParcelDelivery.Services.Entities;
using ParcelDelivery.Services.Handler;
using ParcelDelivery.Services.XmlParser;
using Swashbuckle.AspNetCore.Swagger;

namespace ParcelDelivery.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                             .AddJsonOptions(options =>
                             {
                                 options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                             });

            // Dependency Injection
            services.AddScoped<IParcelHandlerService, ParcelHandlerService>();
            services.AddScoped<IXmlParserService, XmlParserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddTransient<IDepartmentRepository>(s => new DepartmentRepository(Configuration.GetConnectionString("DefaultConnection"),
                                                                                       Configuration.GetConnectionString("DatabaseName")));


            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ParcelDelivery - API", Version = "v1" });
            });
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

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParcelDelivery API");
            });
        }
    }
}

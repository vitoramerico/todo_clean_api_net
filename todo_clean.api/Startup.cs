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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using todo_clean.domain.commands.handlers;
using todo_clean.domain.repositories;
using todo_clean.infra.context;
using todo_clean.infra.datasorces;
using todo_clean.infra.repositories;
using todo_clean.shared.db;

namespace todo_clean.api
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
            services.AddCors();

            services.AddControllers();

            services.AddScoped<MongoDbContext, MongoDbContext>();
            services.AddTransient<ICustomerDataSource, CustomerDataSource>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "todo_clean.api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "todo_clean.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigurationDb.connectionString = Configuration.GetSection("mongoConnection:connectionString").Value;
            ConfigurationDb.databaseName = Configuration.GetSection("mongoConnection:database").Value;
        }
    }
}

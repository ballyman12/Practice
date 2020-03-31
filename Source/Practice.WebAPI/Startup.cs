using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Practice.BusinessLogic.Implement;
using Practice.BusinessLogic.Interface;
using Practice.BusinessLogic.Validation;
using Practice.DataAccess.Implementation;
using Practice.DataAccess.Interface;
using Practice.IoC;
using Practice.Repository.Implement;
using Practice.Repository.Interface;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace Practice.WebAPI
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
            services.AddControllers();
                services.AddDbContext<PracticeContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //this.ConfigureIoC(services);

            services.AddTransient<IPracticeContext, PracticeContext>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemBusinessLogic, ItemBusinessLogic>();
            services.AddTransient<ItemValidation>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
        public virtual void ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry(new SimpleIoCRegistry());
                config.Populate(services);
            });
            container.GetInstance<IServiceProvider>();
        }

        private DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                try
                {
                    var practiceContext = new PracticeContext(GetOptions(Configuration.GetConnectionString("DefaultConnection")));

                    if (!practiceContext.Database.CanConnect())
                    {
                        practiceContext.Database.Migrate();
                        practiceContext.EnsureSeeded();
                    }
                }
                catch (SqlException c)
                {
                    
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}

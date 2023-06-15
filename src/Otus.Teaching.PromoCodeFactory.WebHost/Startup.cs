using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using AutoMapper;
using Otus.Teaching.PromoCodeFactory.DataAccess.Services;
using Otus.Teaching.PromoCodeFactory.DataAccess.Mapping;
using Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration;
using Otus.Teaching.PromoCodeFactory.WebHost.Mapping;

namespace Otus.Teaching.PromoCodeFactory.WebHost
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration Configuration { get; }
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

           
            InstallAutoMapper(services);
            services.AddDbContext<DataContext>(x => 
                x.UseSqlite(Configuration.GetConnectionString("db")));         
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
            services.AddTransient<IPromoCodeService, PromoCodeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            


            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,DataContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }            
            app.UseOpenApi();
            app.UseSwaggerUi3(x =>
            {
                x.DocExpansion = "list";
            });
            InitDB.Init(dbContext);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        private static IServiceCollection InstallAutoMapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                
                cfg.AddProfile<CustomerViewMapProfile>();
                cfg.AddProfile<CustomerMappingProfile>();
                cfg.AddProfile<PreferenceMappingProfile>();
                cfg.AddProfile<PromoCodeViewMappingProfile>();
                cfg.AddProfile<PromoCodeMappingProfile>();

            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
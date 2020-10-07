using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsApp.Core.Interfaces;
using JobsApp.Core.Interfaces.Repositories;
using JobsApp.Core.Models;
using JobsApp.Infrastructure;
using JobsApp.Infrastructure.Repositories;
using JobsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JobsApp
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMemoryCache();

            //Inject repositories
            services.AddTransient<IJobsRepository, JobsRepository>();
            services.AddTransient<ICompaniesRepository, CompaniesRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ILocationsRepository, LocationsRepository>();
            services.AddTransient<IRepositoryManager, RepositoryManager>();

            services.AddHostedService<UpdateJobsHostedService>();
            services.AddScoped<IUpdateJobsBackgroundTask, UpdateJobsBackgroundTask>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Jobs App");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

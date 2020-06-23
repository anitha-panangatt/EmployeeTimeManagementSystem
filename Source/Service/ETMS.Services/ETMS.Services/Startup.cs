using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETMS.Service.BuisinessLayer;
using ETMS.Service.BuisinessLayer.Interfaces;
using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using ETMS.Service.DataAccessLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ETMS.Services
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();

            services.AddScoped<ITimesheetRepository, TimesheetRepository>();
            services.AddScoped<ITimesheetService, TimesheetService>();

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();


            services.AddDbContext<EMTSDbContext>(o =>
            {
                o.UseSqlServer(Configuration["connectionStrings:ETMSConnection"]);
            });


            services.AddControllers();

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

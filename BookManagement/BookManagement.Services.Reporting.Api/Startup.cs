using BookManagement.Services.Reporting.Core.Repositories;
using BookManagement.Services.Reporting.Core.Services;
using BookManagement.Services.Reporting.Core.UnitOfWorks;
using BookManagement.Services.Reporting.Data;
using BookManagement.Services.Reporting.Data.Repositories.EntityFramework;
using BookManagement.Services.Reporting.Data.UnitOfWorks;
using BookManagement.Services.Reporting.Service.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BookManagement.Services.Reporting.Api
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

            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IReportService, ReportService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Services.Report.Api", Version = "v1" });
            });

            services.AddDbContext<BookManagementReportDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgresqlConnection"].ToString(), configure =>
                {
                    configure.MigrationsAssembly("BookManagement.Services.Reporting.Data");
                });
            });

            services.AddMassTransit(x =>
            {
                // Default Port : 5672                
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMQUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManagement.Services.Reporting.Api v1"));
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

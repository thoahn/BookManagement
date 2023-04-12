using BookManagement.Services.Contact.Core.Repositories;
using BookManagement.Services.Contact.Core.Services;
using BookManagement.Services.Contact.Core.UnitOfWork;
using BookManagement.Services.Contact.Data;
using BookManagement.Services.Contact.Data.Repositories.EntityFramework;
using BookManagement.Services.Contact.Data.UnitOfWork;
using BookManagement.Services.Contact.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BookManagement.Services.Contact.Api
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
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonContactService, PersonContactService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookManagement.Services.Contact.Api", Version = "v1" });
            });

            services.AddDbContext<BookManagementDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgresqlConnection"].ToString(),
                    configure =>
                    {
                        configure.MigrationsAssembly("BookManagement.Services.Contact.Data");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManagement.Services.Contact.Api v1"));
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

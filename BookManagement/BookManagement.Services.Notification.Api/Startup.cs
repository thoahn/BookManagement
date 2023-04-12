﻿using BookManagement.Services.Notification.Api.Consumers;
using BookManagement.Services.Notification.Api.Services;
using BookManagement.Services.Notification.Api.Services.Abstract;
using BookManagement.Shared;
using MassTransit;
using Microsoft.OpenApi.Models;

namespace BookManagement.Services.Notification.Api
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
            services.Configure<Settings>(Configuration.GetSection("ServiceSettings"));
            services.AddHttpClient<IReportService, ReportService>();
            services.AddHttpClient<IPersonService, PersonService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookManagement.Services.Notification.Api", Version = "v1" });
            });

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateReportMessageCommandConsumer>();
                // Default Port : 5672
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMQUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("create-report-service", e =>
                    {
                        e.ConfigureConsumer<CreateReportMessageCommandConsumer>(context);
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManagement.Services.Notification.Api v1"));
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

using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Notification.Extensions;
using Notification.Filters;
using Notification.Models.Context;
using Notification.Services.Contracts;
using Notification.Services.Implementation;
using Notification.Services.Options;
using System.Reflection;

namespace Notification
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private IConfiguration configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString(nameof(RedisCacheService));
            });
            services.AddEntityFrameworkNpgsql().AddDbContext<PostgresNotificationDataContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString(nameof(PostgresNotificationDataContext))));
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            services.Configure<RedisOptions>(configuration);

            services.AddTransient<ICacheService, RedisCacheService>();
            services.AddHealthChecks()
                .AddRedis(configuration.GetConnectionString(nameof(RedisCacheService)))
                .AddNpgSql(configuration.GetConnectionString(nameof(PostgresNotificationDataContext)));
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API V1");
            });

            app.UseRequestLogger();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

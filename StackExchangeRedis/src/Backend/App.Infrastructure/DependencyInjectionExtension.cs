using App.Domain.Enums;
using App.Domain.Repositories;
using App.Domain.Repositories.Product;
using App.Domain.Services.Cache;
using App.Infrastructure.DataAccess;
using App.Infrastructure.Extensions;
using App.Infrastructure.Repositories;
using App.Infrastructure.Services.Cache;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);

            if (configuration.IsUnitTestEnvironment())
                return;

            var databaseType = configuration.DatabaseType();

            if (databaseType == DatabaseType.SQLServer)
            {
                AddDbContextSqlServer(services, configuration);
                AddFluentMigrator_SqlServer(services, configuration);
            }

            AddRedisCache(services, configuration);

        }
        private static void AddDbContextSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddDbContext<ProductAppDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
        private static void AddFluentMigrator_SqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("App.Infrastructure")).For.All();
            });
        }

        //Added Redis 
        public static void AddRedisCache(IServiceCollection services, IConfiguration configuration)
        {
            var redisConnection = configuration.GetValue<string>("ConnectionStrings:Redis");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnection;
                options.InstanceName = "Products_";
            } );

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
            services.AddScoped<IProductDeleteOnlyRepository, ProductRepository>();
            services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();
            services.AddScoped<IProductUpdateOnlyRepository, ProductRepository>();
            services.AddScoped<IRedisCacheService, RedisCacheService>(); //Added Redis caching.

        }
    }
}

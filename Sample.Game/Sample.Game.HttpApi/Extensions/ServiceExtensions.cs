using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Game.Contracts;
using Sample.Game.Entities;
using Sample.Game.Entities.Models;
using Sample.Game.Entities.ResponseType.DataShaping;
using Sample.Game.Repository;

namespace Sample.Game.HttpApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AnyPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination"));
            });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("GameDb");
            services.AddDbContext<GameDbContext>(
                builder => builder.UseMySql(connectionString, ServerVersion.FromString("5.7")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
        }

    }
}

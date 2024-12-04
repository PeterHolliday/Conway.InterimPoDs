using Conway.InterimPods.Application;
using Conway.InterimPods.Core.Entities;
using Conway.InterimPods.Core.Interfaces;
using Conway.InterimPods.Infrastructure.Data;
using Conway.InterimPods.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Conway.InterimPods.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddPersistence(services, configuration);

            return services;
        }

        public static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<PodScansDbContext>(options =>
            {
                options.UseOracle(connectionString)
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }, ServiceLifetime.Scoped);

            services.AddScoped(typeof(IPodScanRepository), typeof(PodScanRepository));
            services.AddScoped<PodScanService>();

            services.AddScoped<RemoteApiOptions>();
        }
    }
}

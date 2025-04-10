using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NET.Veterinary.CA.Domain.IRepositories;
using NET.Veterinary.CA.Infrastructure.Persistence.Context;
using NET.Veterinary.CA.Infrastructure.Persistence.Repositories;

namespace NET.Veterinary.CA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services, configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddDbContext<AppDBContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)));
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
        services.AddTransient<IAppDBContext>(provider => provider.GetService<AppDBContext>());
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        return services;
    }
}

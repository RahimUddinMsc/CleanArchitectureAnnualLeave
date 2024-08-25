using Application.Contracts.Providers;
using Application.Services;
using Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Contracts.Database;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddSingleton<NotificationHubService<NotificationHub>>();
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        return services;
    }
}
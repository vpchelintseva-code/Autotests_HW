using Autotests.TryApp.Interfaces;
using Autotests.TryApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Autotests.TryApp.Modules;

public static class UserModule
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, string url)
    {
        services.AddScoped<IUserApi>(_ => RestService.For<IUserApi>(new HttpClient
        {
            BaseAddress = new Uri(url)
        }));
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}

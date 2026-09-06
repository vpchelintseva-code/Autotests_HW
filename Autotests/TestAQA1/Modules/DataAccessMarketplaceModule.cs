using System;
using Microsoft.Extensions.DependencyInjection;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;
using Autotests.TestAQA1.Repository;

namespace Autotests.TestAQA1.Modules
{
    public static class DataAccessMarketplaceModule
    {
        public static IServiceCollection AddDataAccessMarketplace(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository>(p => new UserRepository(connectionString));
            services.AddScoped<IAddressRepository>(p => new AddressRepository(connectionString));
            services.AddScoped<IMarketItemsRepository>(p => new MarketItemsRepository(connectionString));
            return services;
        }
    }
}

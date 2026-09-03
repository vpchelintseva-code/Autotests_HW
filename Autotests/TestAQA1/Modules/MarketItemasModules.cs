using Microsoft.Extensions.DependencyInjection;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;
using Autotests.TestAQA1.Repository;

namespace Autotests.TestAQA1.Modules
{
    public static class MarketItemsRepository
    {
        public static IServiceCollection AddMarketItemsRepository(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IMarketItemsRepository>(p => new MarketItemsRepository(connectionString));
            return services;
        }
    }
    
}
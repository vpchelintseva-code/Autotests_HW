using System;
using Microsoft.Extensions.DependencyInjection;
using Autotests.TestAQA1.Modules;

namespace Autotests.TestAQA1.Preconditions
{
    public class DataBasePreconditions
    {
        public ServiceProvider Provider { get; }

        public DataBasePreconditions()
        {
            var services = new ServiceCollection();
            services.AddDataAccessMarketplace("Data Source=marketplace.db");
            Provider = services.BuildServiceProvider();
        }
    }
}


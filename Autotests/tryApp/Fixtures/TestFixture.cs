using Autotests.TryApp.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Autotests.TryApp.Fixtures;

public sealed class TestFixture
{
    public IServiceProvider Provider { get; }

    public TestFixture()
    {
        var services = new ServiceCollection();
        services.AddUsersModule("https://reqres.in/api/");
        Provider = services.BuildServiceProvider();
    }
}

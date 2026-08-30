using Autotests.TryApp.Fixtures;
using Autotests.TryApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Autotests.TryApp.Tests;

public sealed class Tests
{
    private readonly TestFixture fixture = new();

    [Test]
    public void ServiceIsRegistered()
    {
        var service = fixture.Provider.GetRequiredService<IUserService>();
        Assert.That(service.IsUserValid(1), Is.True);
    }
}

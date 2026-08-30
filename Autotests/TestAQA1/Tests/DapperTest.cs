using System;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Autotests.TestAQA1;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;
using Autotests.TestAQA1.Preconditions;
using FluentAssertions;

namespace Autotests.TestAQA1.Tests;

public class DapperTests
{
    private readonly DataBasePreconditions p = new();
        //[Test] //генерация базы - раскомментить, а потом запустить тест разово/**//*
        // public async Task InitialiseTest()
        // {
        //     var connectionString = "Data Source=marketplace.db";
        //     await using var connection = new SqliteConnection(connectionString);
        //     await connection. OpenAsyncO);
        //     await DatabaseInitializer.InitializeAsync(connection);
        // }

    public async Task CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo!.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo!.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users!.FirstName.Should().Be("Мария");
        }
        
        [Test]
        public async Task GetAdressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo!.GetAddressByUserIdAsync(1);
            address.Should().NotBeNull();
        }
}

using System;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Autotests.TestAQA1;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;
using Autotests.TestAQA1.Preconditions;
using FluentAssertions;

namespace Autotests.TestAQA1.Tests
{
    public class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();
       
        //[Test] //генерация базы - раскомментить, а потом запустить тест разово/**//*
        // public async Task InitialiseTest()
        // {
        //     var connectionString = "Data Source=marketplace.db";
        //     await using var connection = new SqliteConnection(connectionString);
        //     await connection. OpenAsyncO);
        //     await DatabaseInitializer.InitializeAsync(connection);
        // }

        [Test]
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
        
        
        [Test]// Проверяем кол-во полученных категорий
        public async Task GetCategoriesAsync()
        {
            var repo = p.Provider.GetService<IMarketItemsRepository>();
            var categories = await repo.GetCategoriesAsync();
            categories.Should().HaveCount(6);
        }
        
        [Test]//провекра полей конкретного продукта запрошенного по id
        public async Task GetProduct_whatWeExpected()
        {
            var repo = p.Provider.GetRequiredService<IMarketItemsRepository>();
            var product = await repo.GetProductAsync(5);
            product.Should().NotBeNull();
            product!.Id.Should().Be(5);
            product.Name.Should().Be("Lenovo IdeaPad 5");
            product.Price.Should().Be(74990);
            product.Stock.Should().Be(18);
            product.CategoryId.Should().Be(2);

        }

        [Test] // 2.3 Получить из таблицы Orders конкретный заказ конкретного юзера и проверить, что в нем именно те товары (Items), которые в нем должны быть (это уже в таблице OrderItems и Products)
        public async Task GetOrderByUserIdWithItems()
        {
            var repo = p.Provider.GetRequiredService<IMarketItemsRepository>();
            var order = await repo.GetOrderWithItemsAsync( orderId: 16, userId: 1);
            order!.id.Should().Be(16);
            order.userId.Should().Be(1);
            order.Items.Should().HaveCount(2);
            order.Items.Select(item => item.ProductName).Should().Contain("USB-C Hub", "Anker PowerBank");

        }
        
        
    }
}

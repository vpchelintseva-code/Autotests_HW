using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Autotests.TestAQA1.DTO.UsersDTO;

namespace Autotests.TestAQA1.Tests
{
    public class UserDataTest
    {
        private RootDTO root = null!;

            [OneTimeSetUp]
            public void Setup()
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
                string json = File.ReadAllText(path);
                root = JsonSerializer.Deserialize<RootDTO>(json)!;
            }

            [Test] //2.1 Проверить, что количество юзеров из файла равно 10
            public void Test1_CountUsers10()
            {
                root.Data.Should().HaveCount(10);
            }

            [Test] // 2.2 Проверить, что первый юзер - Alice Johnson
            public void Test2_CheckPositionAliceJohnson()
            {
                root.Data.First().Profile.FullName.Should().Be("Alice Johnson");
            }

            [Test] // 2.3 Проверить, что все Id уникальны 
            public void Test3_CheckUniqID()
            {
                var usersIds = root.Data.Select(user => user.Id).ToList();
                usersIds.Should().OnlyHaveUniqueItems();
            }

            [Test] // 2.4 Проверить, что есть хотя бы один премиум-пользователь (тег premium)
            public void Test4_CheckPremiumUser()
            {
                var atLeastOneWithPremium = root.Data.Any(user => user.Profile.Tags.Contains("premium"));
                atLeastOneWithPremium.Should().BeTrue();
            }

            [Test] // 2.5 Проверить, что у всех юзеров поле город - не пустой
            public void Test5_CheckCityIsNotNull()
            {
                var allCitiesFilled = root.Data.All(user => !string.IsNullOrWhiteSpace(user.Profile.Address.City));
                allCitiesFilled.Should().BeTrue();
            }

            [Test] // 2.6 Проверить, что есть хотя бы один пользователь из Стокгольма
            public void Test6_OneUserIsFromStockholm()
            {
                var OneUserIsFromStockholm = root.Data.Any(user => user.Profile.Address.City == "Stockholm");
                OneUserIsFromStockholm.Should().BeTrue();
            }

            [Test] // 2.7 Проверить, что возраст всех юзеров в диапазоне 18-60 лет
            public void Test7_AllAgesAreBetween18And60()
            {
                var AllAgesAreBetween18And60 = root.Data.All(user => user.Profile.Age >=18 && user.Profile.Age <= 60);
                AllAgesAreBetween18And60.Should().BeTrue();
            }

            [Test] // 2.8 Проверить, что есть хотя бы один юзер с ролью admin
            public void Test8_OneUserWithRoleAdmin()
            {
                var OneUserWithRoleAdmin = root.Data.Any(user => user.Roles.Contains("admin"));
                OneUserWithRoleAdmin.Should().BeTrue();
            }

            [Test] // 3. Проверить, что все юзеры (их координаты) находятся в диапазоне Швеции
            public void Test9_CheckAllUsersHaveGeoNearSweden()
            {
                var coordinates = root.Data
                    .Select(user => user.Profile.Address.Geo)
                    .ToList();
                coordinates.Should().OnlyContain(geo =>
                    geo.Lat >= 55.0 &&
                    geo.Lat <= 69.1 &&
                    geo.Lng >= 11.0 &&
                    geo.Lng <= 24.2);
            }
            
    }
}


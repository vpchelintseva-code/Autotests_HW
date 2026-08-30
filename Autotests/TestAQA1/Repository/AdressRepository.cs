using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Autotests.TestAQA1.DTO.DapperTestsDTO;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;

namespace Autotests.TestAQA1.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connection;
        public AddressRepository(string connection)
        {
            this.connection = connection;
        }
        
        public async Task<AddressDTO?> GetAddressByUserIdAsync(int userId)
        {
            using var db = new SqliteConnection(connection);
            return await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * FROM Addresses WHERE UserId = @userId", new { userId });
        }
    }
}


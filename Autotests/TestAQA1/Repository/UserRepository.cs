using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Autotests.TestAQA1.DTO.DapperTestsDTO;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;

namespace Autotests.TestAQA1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string connection;
        public UserRepository (string connection)
        {
            this.connection = connection;
        }
        public async Task<IEnumerable<UsersDTO>> GetUsersAsync()
        {
            using var db = new SqliteConnection(connection);
            var users = await db.QueryAsync<UsersDTO>("SELECT * from Users");
            return users;
        }
        public async Task<UsersDTO> GetUserByIdAsync(int id)
        {
            using var db = new SqliteConnection (connection);
            var userById = await db.QueryFirstOrDefaultAsync<UsersDTO>("SELECT * FROM Users WHERE Id = @id", new { id });
            return userById;
        }

        public async Task<UsersDTO> GetUserByNameAndSurname(string firstName, string lastName)
        {
            using var db = new SqliteConnection(connection);
            var userByName = await db.QueryFirstOrDefaultAsync<UsersDTO>("SELECT * FROM Users " +
                                                                         "WHERE FirstName = @firstName AND LastName = @lastName", new { firstName, lastName });
            return userByName;
        }
    
    }
    
        
}

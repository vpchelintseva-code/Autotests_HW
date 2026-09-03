using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Autotests.TestAQA1.DTO.DapperTestsDTO;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;

namespace Autotests.TestAQA1.Repository
{
    public class MarketItemsRepository : IMarketItemsRepository
    {
        private readonly string connectionString;
        public MarketItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<>
    }
}


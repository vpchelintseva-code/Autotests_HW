using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Autotests.TestAQA1.DTO.DapperTestsDTO;
using Autotests.TestAQA1.Interfaces.DapperTestsInterfaces;

    public class MarketItemsRepository : IMarketItemsRepository
    {
        private readonly string connectionString;
        public MarketItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync ()
        {
            using var db = new SqliteConnection(connectionString);
            return await db.QueryAsync<CategoryDTO>("SELECT * FROM Categories");
        }
    public async Task<ProductDTO?> GetProductAsync( long productId)
    
    {
        using var db = new SqliteConnection(connectionString);
        return await db.QueryFirstOrDefaultAsync<ProductDTO>(
            "SELECT Id, Name, Description, Price, Stock, CategoryId FROM Products WHERE Id = @productId;", new { productId });
    }

    public async Task<OrderWithItemsDTO?> GetOrderWithItemsAsync(long orderId, long userId)

    {
        using var db = new SqliteConnection(connectionString);
        var row = await db.QueryAsync<OrderWithItemRow>("SELECT o.Id, o.UserId, o.OrderDate, o.Status, o.TotalPrice, oi.ProductId, p.Name AS ProductName, oi.Quantity, oi.UnitPrice " +
                                                        "FROM Orders o JOIN OrderItems OI ON oi.OrderId = o.Id " +
                                                        "JOIN Products p ON p.Id = oi.ProductId WHERE o.Id = @orderId AND o.UserId  = @userId", new { orderId, userId });
        
        var firstRow = row.FirstOrDefault();
        if (firstRow is null)
            return null;

        var items = row.Select(row => new OrderItemProductDTO
        (
            row.ProductId, 
            row.ProductName, 
            row.Quantity, 
            row.UnitPrice)).ToList();

        return new OrderWithItemsDTO(
            firstRow.Id,
            firstRow.UserId,
            firstRow.OrderDate,
            firstRow.Status,
            firstRow.TotalPrice,
            items
        );
    }

    private sealed class OrderWithItemRow
    
        {
            public long Id { get; set; }
            public long UserId { get; set; }
            public string OrderDate { get; set; }
            public string Status { get; set; }
            public decimal TotalPrice { get; set; }
            public long ProductId { get; set; }
            public string ProductName { get; set; }
            public long Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
    
    
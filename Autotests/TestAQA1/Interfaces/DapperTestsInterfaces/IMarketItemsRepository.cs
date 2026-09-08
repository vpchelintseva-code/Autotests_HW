using System;
using Autotests.TestAQA1.DTO.DapperTestsDTO;

namespace Autotests.TestAQA1.Interfaces.DapperTestsInterfaces
{
    public interface IMarketItemsRepository
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<ProductDTO> GetProductAsync(long productId);
        Task<OrderWithItemsDTO?>  GetOrderWithItemsAsync(long orderId, long userId);

        Task<IEnumerable<string>> GetCitiesOfUsersWhoBoughtCategoryAsync(string categoryName);
        Task<IEnumerable<long>> GetUserIdsWhoBoughtCategoryAsync(string categoryName);
        
    }
}

        

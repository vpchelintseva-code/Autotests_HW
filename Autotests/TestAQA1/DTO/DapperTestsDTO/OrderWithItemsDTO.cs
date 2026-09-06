using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record OrderWithItemsDTO
        (
                        long id,
                        long userId,
                        string orderDate,
                        string status,
                        decimal totalPrice,
                        List<OrderItemProductDTO> Items
                        );
}
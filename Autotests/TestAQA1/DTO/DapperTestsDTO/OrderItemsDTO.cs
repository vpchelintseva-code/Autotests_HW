using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
    (
        long Id,
        long OrderId,
        long ProductId,
        long Quantity,
        decimal UnitPrice
    );
}

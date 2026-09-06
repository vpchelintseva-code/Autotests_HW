using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record OrderItemProductDTO
    (
        long ProductId,
        string ProductName,
        long Quantity,
        decimal UnitPrice
    );
}
    
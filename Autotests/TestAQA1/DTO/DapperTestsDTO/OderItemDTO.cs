using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
    (
        long id,
        long orderId,
        long productId,
        long quantity,
        long unitPrice
    );
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record OrderDTO
    (
        int Id,
        long UserId,
        string OrderDate,
        string Status,
        decimal TotalPrice
    );
}

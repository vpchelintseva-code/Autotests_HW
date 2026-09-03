using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record ReviewsDTO
    (
        long Id,
        long UserId,
        long ProductId,
        long Rating,
        string Comment,
        string CreatedAt
    );
}

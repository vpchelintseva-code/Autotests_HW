using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record ReviewsDTO
    (
        long id,
        long userId,
        long productId,
        long rating,
        string? comment,
        string createdAt
    );
}

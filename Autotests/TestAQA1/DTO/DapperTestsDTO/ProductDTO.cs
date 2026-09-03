using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record ProductDTO
    (
        long Id,
        string Name,
        string Description,
        decimal Price,
        long Stock,
        long CategoryId
    );
}

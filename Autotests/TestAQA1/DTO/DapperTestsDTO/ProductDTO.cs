using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record ProductDTO
    (
        long id,
        string name,
        string description,
        decimal price,
        long stock,
        long categoryId
    );
}

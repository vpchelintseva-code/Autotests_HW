using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.UsersDTO
{
    public record RootDTO
    (
        [property: JsonPropertyName("data")] IReadOnlyList<DataDTO> Data
    );
}
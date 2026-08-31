using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.UsersDTO
{ 
    public record ProfileDTO
    (
        [property: JsonPropertyName("fullName")] string FullName,
        [property: JsonPropertyName("age")] int Age,
        [property: JsonPropertyName("address")] AddressDTO Address,
        [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags
    );
}
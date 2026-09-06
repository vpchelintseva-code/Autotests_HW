using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.UsersDTO
{ 
    public record DataDTO
    (
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("username")] string username,
        [property: JsonPropertyName("profile")] ProfileDTO Profile,
        [property: JsonPropertyName("roles")] IReadOnlyList<string> Roles
    );
}
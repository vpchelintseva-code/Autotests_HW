
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO;

public record CustomerDTO
(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("email")] string email,
    [property: JsonPropertyName("phone")] string phone,
    [property: JsonPropertyName("address")] string address
);

//customer": {
// "id": 102,
// "name": "Olga Petrova",
// "email": "olga.petrova@example.com",
// "phone": "+46701234567",
// "address": {
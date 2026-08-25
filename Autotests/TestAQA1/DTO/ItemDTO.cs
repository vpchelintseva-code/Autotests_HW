using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO;


public record ItemDTO
(
    [property: JsonPropertyName("productId")]
    string productId,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("category")] string category,
    [property: JsonPropertyName("quantity")] string quantity,
    [property: JsonPropertyName("price")] decimal price
);

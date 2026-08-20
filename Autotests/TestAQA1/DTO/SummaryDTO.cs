using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO;

public record SummaryDTO
(
    [property: JsonPropertyName("itemsTotal")] string itemsTotal,
    [property: JsonPropertyName("deliveryFee")] string deliveryFee,
    [property: JsonPropertyName("discount")] string discount,
    [property: JsonPropertyName("finalTotal")] string finalTotal
);
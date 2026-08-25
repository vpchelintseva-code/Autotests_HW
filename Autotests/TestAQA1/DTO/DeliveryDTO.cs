using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO;


public record DeliveryDTO
(
    [property: JsonPropertyName("type")] string type,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("estimatedDate")] string estimatedDate,
    [property: JsonPropertyName("trackingNumber")] string trackingNumber
);
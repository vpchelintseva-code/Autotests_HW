using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO;


public record PaymentDTO
(
    [property: JsonPropertyName("method")] string method,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("transactionId")] string transactionId
);


using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO;


public record AdressDTO
(
  [property: JsonPropertyName("country")]
  string Country,
  [property: JsonPropertyName("city")] string City,
  [property: JsonPropertyName("street")] string State,
  [property: JsonPropertyName("zip")] string Zip
);
    
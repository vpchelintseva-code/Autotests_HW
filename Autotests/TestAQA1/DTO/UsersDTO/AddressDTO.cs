using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.UsersDTO
{
    public record AddressDTO
    (
        [property: JsonPropertyName("street")] string Street,
        [property: JsonPropertyName("city")] string City,
        [property: JsonPropertyName("geo")] GeoDTO Geo
    );
}

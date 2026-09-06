using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Autotests.TestAQA1.DTO.UsersDTO
{
    public record GeoDTO
    (
        [property: JsonPropertyName("lat")] double Lat,
        [property: JsonPropertyName("lng")] double Lng
    );
}


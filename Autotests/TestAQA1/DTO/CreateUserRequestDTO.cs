using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestAQA1
{
    internal class CreateUserRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("job")]
        public string Job { get; set; } = string.Empty;
        
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        
        [JsonPropertyName("CreatedAt")]
        public string CreatedAt { get; set; } = string.Empty;
    }
}
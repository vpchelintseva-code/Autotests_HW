using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
namespace Autotests.TestAQA1.DTO

{
    public class CreateUserRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("job")]
        public string Job { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("CreatedAt")]
        public string CreatedAt { get; set; }
    }
}
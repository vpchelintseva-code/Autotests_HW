using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
namespace Autotests.TestAQA1.DTO

{
    public class CreateUserResponseDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")] 
        public string Job { get; set; }
    }
}
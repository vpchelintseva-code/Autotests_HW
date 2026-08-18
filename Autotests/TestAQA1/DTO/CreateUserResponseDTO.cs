using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestAQA1
{
    public class CreateUserResponseDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("job")] 
        public string Job { get; set; } = string.Empty;
        //string.Empty добавила чтобы небыло присвоено значения null, даже если в JSON отсутствует это поле
    }
}
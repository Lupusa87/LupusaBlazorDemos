using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlazorCounterHelper
{
    [Serializable]
    public class TSCounter
    {
        [JsonPropertyName("q")]
        [JsonProperty(PropertyName = "q")]
        public Guid ID { get; set; } = Guid.Empty;


        [JsonPropertyName("w")]
        [JsonProperty(PropertyName = "w")]
        public string Source { get; set; }


        [JsonPropertyName("e")]
        [JsonProperty(PropertyName = "e")]
        public string Action { get; set; }

        [JsonPropertyName("r")]
        [JsonProperty(PropertyName = "r")]
        public DateTime Date { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlazorCounterHelper
{
    [Serializable]
    public class TSReport1
    {
        [JsonPropertyName("w")]
        [JsonProperty(PropertyName = "w")]
        public string Source { get; set; }


        [JsonPropertyName("e")]
        [JsonProperty(PropertyName = "e")]
        public string Action { get; set; }

        [JsonPropertyName("r")]
        [JsonProperty(PropertyName = "r")]
        public int Count { get; set; }
    }
}

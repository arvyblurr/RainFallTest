using Newtonsoft.Json;

namespace RainFallApi.ApiProvider;

public class RawResponseModel
{
   [JsonProperty("@Id")]
    public string Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Measure { get; set; }
    public double Value { get; set; }
}


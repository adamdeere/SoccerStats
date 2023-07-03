using Newtonsoft.Json;

namespace SoccerStatsData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CountryPaging
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class CountryHttpResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }

    public class CountryRoot
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        [JsonProperty("parameters")]
        public List<object> Parameters { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("paging")]
        public CountryPaging Paging { get; set; }

        [JsonProperty("response")]
        public List<CountryHttpResponse> Response { get; set; }
    }
}
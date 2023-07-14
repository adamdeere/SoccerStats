using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class League
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("season")]
        public int? Season { get; set; }
    }
}
using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class Predictions
    {
        [JsonProperty("winner")]
        public Winner Winner { get; set; }

        [JsonProperty("win_or_draw")]
        public bool? WinOrDraw { get; set; }

        [JsonProperty("goals")]
        public PredictionGoals Goals { get; set; }

        [JsonProperty("advice")]
        public string Advice { get; set; }

        [JsonProperty("percent")]
        public Percent Percent { get; set; }
    }

    public class Winner
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
    public class PredictionGoals 
    {
        [JsonProperty("home")]
        public string? Home { get; set; }

        [JsonProperty("away")]
        public string? Away { get; set; }
    }
    public class Percent
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("draw")]
        public string Draw { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }

   
}

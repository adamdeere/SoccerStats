using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class PredictionRoot
    {
        [JsonProperty("response")]
        public List<PredictionResponse> Response { get; set; }
    }

    public class PredictionResponse
    {
        [JsonProperty("predictions")]
        public Predictions Predictions { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("teams")]
        public Teams Teams { get; set; }

        [JsonProperty("comparison")]
        public PredictionComparison Comparison { get; set; }

        [JsonProperty("h2h")]
        public List<HeadToHeadStats> HeadToHeadStats { get; set; }
    }
}
using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class PredictionComparison
    {
        [JsonProperty("form")]
        public ComparisonStats Form { get; set; }

        [JsonProperty("att")]
        public ComparisonStats Att { get; set; }

        [JsonProperty("def")]
        public ComparisonStats Def { get; set; }

        [JsonProperty("poisson_distribution")]
        public ComparisonStats PoissonDistribution { get; set; }

        [JsonProperty("h2h")]
        public ComparisonStats HeadToHead { get; set; }

        [JsonProperty("goals")]
        public ComparisonStats Goals { get; set; }
        [JsonProperty("total")]
        public ComparisonStats Total { get; set; }
    }

    public class ComparisonStats
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }
}

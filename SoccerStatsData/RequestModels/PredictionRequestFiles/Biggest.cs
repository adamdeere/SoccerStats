using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class Biggest
    {
        [JsonProperty("streak")]
        public Streak Streak { get; set; }

        [JsonProperty("wins")]
        public BiggestWinLoss Wins { get; set; }

        [JsonProperty("loses")]
        public BiggestWinLoss Loses { get; set; }

        [JsonProperty("goals")]
        public BiggestGoals Goals { get; set; }
    }

    public class BiggestGoals
    {
        [JsonProperty("for")]
        public GoalNumbers For { get; set; }
        [JsonProperty("against")]
        public GoalNumbers Againsr { get; set; }
    }

    public class GoalNumbers
    {
        public int? Home { get; set; }

        public int? Away { get; set; }
    }

    public class Streak
    {
        [JsonProperty("wins")]
        public int? Wins { get; set; }

        [JsonProperty("draws")]
        public int? Draws { get; set; }

        [JsonProperty("loses")]
        public int? Loses { get; set; }
    }

    public class BiggestWinLoss
    {
        [JsonProperty("home")]
        public string? Home { get; set; }

        [JsonProperty("away")]
        public string? Away { get; set; }
    }
}

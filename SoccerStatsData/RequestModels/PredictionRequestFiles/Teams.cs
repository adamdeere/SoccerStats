using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class Teams
    {
        [JsonProperty("home")]
        public Team? Home { get; set; }

        [JsonProperty("away")]
        public Team? Away { get; set; }
    }

    public class Team
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("logo")]
        public string? Logo { get; set; }
        [JsonProperty("last_5")]
        public Last5 Last_Five { get; set; }
        [JsonProperty("league")]
        public LeagueForm League { get; set; }
    }

    public class Last5
    {
        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("att")]
        public string Att { get; set; }

        [JsonProperty("def")]
        public string Def { get; set; }

        [JsonProperty("goals")]
        public LastFiveGoals Goals { get; set; }
    }

    public class LastFiveGoals
    {
        [JsonProperty("for")]
        public LastFiveGoalStats GoalsFor { get; set; }

        [JsonProperty("against")]
        public LastFiveGoalStats GoalsAgainst { get; set; }
    }

    public class LastFiveGoalStats 
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("average")]
        public string? Average { get; set; }
    }

    
}

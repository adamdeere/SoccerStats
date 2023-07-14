using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class HeadToHeadStats
    {
        [JsonProperty("fixture")]
        public Fixture Fixture { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("teams")]
        public HeadToHeadTeams Teams { get; set; }

        [JsonProperty("goals")]
        public HeadToHeadGoals Goals { get; set; }

        [JsonProperty("score")]
        public HeadToHeadScore Scores { get; set; }
    }

    public class Fixture
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("referee")]
        public string Referee { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("timestamp")]
        public int? Timestamp { get; set; }

        [JsonProperty("periods")]
        public Periods Periods { get; set; }

        [JsonProperty("venue")]
        public PredictionVenue Venue { get; set; }

        [JsonProperty("status")]
        public PredictionStatus Status { get; set; }
    }

    public class PredictionVenue
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }

    public class PredictionStatus
    {
        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("elapsed")]
        public int? Elapsed { get; set; }
    }

    public class Periods
    {
        [JsonProperty("first")]
        public int? First { get; set; }

        [JsonProperty("second")]
        public int? Second { get; set; }
    }

    public class HeadToHeadTeams
    {
        [JsonProperty("home")]
        public HeadToHeadTeam Home { get; set; }

        [JsonProperty("away")]
        public HeadToHeadTeam Away { get; set; }
    }

    public class HeadToHeadTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("winner")]
        public bool? Winnder { get; set; }
    }

    public class HeadToHeadGoals
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }
    }

    public class HeadToHeadScore
    {
        [JsonProperty("halftime")]
        public HeadToHeadGoals HalfTime { get; set; }

        [JsonProperty("fulltime")]
        public HeadToHeadGoals FullTime { get; set; }

        [JsonProperty("extratime")]
        public HeadToHeadGoals ExtraTime { get; set; }

        [JsonProperty("penalty")]
        public HeadToHeadGoals Penalty { get; set; }
    }
}
using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels
{
    public class Away
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("winner")]
        public object Winner { get; set; }
    }

    public class Extratime
    {
        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }
    }

    public class Fixture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("referee")]
        public object Referee { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("periods")]
        public PredictionPeriods Periods { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Fulltime
    {
        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }
    }

    public class Halftime
    {
        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }
    }

    public class Home
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("winner")]
        public object Winner { get; set; }
    }

    public class League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }
    }

    public class Penalty
    {
        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }
    }

    public class PredictionPeriods
    {
        [JsonProperty("first")]
        public object First { get; set; }

        [JsonProperty("second")]
        public object Second { get; set; }
    }

    public class FixtureResponse
    {
        [JsonProperty("fixture")]
        public Fixture Fixture { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("teams")]
        public Teams Teams { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        [JsonProperty("score")]
        public Score Score { get; set; }
    }

    public class Goals
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }
    }

    public class FixtureRoot
    {
        [JsonProperty("response")]
        public List<FixtureResponse> Response { get; set; }
    }

    public class Score
    {
        [JsonProperty("halftime")]
        public Halftime Halftime { get; set; }

        [JsonProperty("fulltime")]
        public Fulltime Fulltime { get; set; }

        [JsonProperty("extratime")]
        public Extratime Extratime { get; set; }

        [JsonProperty("penalty")]
        public Penalty Penalty { get; set; }
    }

    public class Status
    {
        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("elapsed")]
        public object Elapsed { get; set; }
    }

    public class Teams
    {
        [JsonProperty("home")]
        public Home Home { get; set; }

        [JsonProperty("away")]
        public Away Away { get; set; }
    }

    public class Venue
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
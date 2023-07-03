using Newtonsoft.Json;

namespace SoccerStatsData
{
  
    public class LeagueCountry
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }

    public class LeagueCoverage
    {
        [JsonProperty("fixtures")]
        public LeagueFixtures Fixtures { get; set; }

        [JsonProperty("standings")]
        public bool Standings { get; set; }

        [JsonProperty("players")]
        public bool Players { get; set; }

        [JsonProperty("top_scorers")]
        public bool TopScorers { get; set; }

        [JsonProperty("top_assists")]
        public bool TopAssists { get; set; }

        [JsonProperty("top_cards")]
        public bool TopCards { get; set; }

        [JsonProperty("injuries")]
        public bool Injuries { get; set; }

        [JsonProperty("predictions")]
        public bool Predictions { get; set; }

        [JsonProperty("odds")]
        public bool Odds { get; set; }
    }

    public class LeagueFixtures
    {
        [JsonProperty("events")]
        public bool Events { get; set; }

        [JsonProperty("lineups")]
        public bool Lineups { get; set; }

        [JsonProperty("statistics_fixtures")]
        public bool StatisticsFixtures { get; set; }

        [JsonProperty("statistics_players")]
        public bool StatisticsPlayers { get; set; }
    }

    public class PlayerPlayerLeague
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    

    public class LeagueResponse
    {
        [JsonProperty("league")]
        public PlayerPlayerLeague League { get; set; }

        [JsonProperty("country")]
        public LeagueCountry Country { get; set; }

        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }

    public class LeagueRoot
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        [JsonProperty("parameters")]
        public List<object> Parameters { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("response")]
        public List<LeagueResponse> Response { get; set; }
    }

    public class Season
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("current")]
        public bool Current { get; set; }

        [JsonProperty("coverage")]
        public LeagueCoverage Coverage { get; set; }
    }
}
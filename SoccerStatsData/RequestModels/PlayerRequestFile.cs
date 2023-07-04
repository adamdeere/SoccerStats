using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PlayerBirth
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class PlayerCards
    {
        [JsonProperty("yellow")]
        public int? Yellow { get; set; }

        [JsonProperty("yellowred")]
        public int? Yellowred { get; set; }

        [JsonProperty("red")]
        public int? Red { get; set; }
    }

    public class PlayerDribbles
    {
        [JsonProperty("attempts")]
        public int? Attempts { get; set; }

        [JsonProperty("success")]
        public object Success { get; set; }

        [JsonProperty("past")]
        public object Past { get; set; }
    }

    public class PlayerDuels
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("won")]
        public int? Won { get; set; }
    }

    public class PlayerFouls
    {
        [JsonProperty("drawn")]
        public int? Drawn { get; set; }

        [JsonProperty("committed")]
        public int? Committed { get; set; }
    }

    public class PlayerGames
    {
        [JsonProperty("appearences")]
        public int? Appearences { get; set; }

        [JsonProperty("lineups")]
        public int? Lineups { get; set; }

        [JsonProperty("minutes")]
        public int? Minutes { get; set; }

        [JsonProperty("number")]
        public object Number { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }
    }

    public class PlayerGoals
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("conceded")]
        public int? Conceded { get; set; }

        [JsonProperty("assists")]
        public int? Assists { get; set; }

        [JsonProperty("saves")]
        public object Saves { get; set; }
    }

    public class PlayerLeague
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
    }

    public class PlayerPaging
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class PlayerParameters
    {
        [JsonProperty("league")]
        public string League { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }
    }

    public class PlayerPasses
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("key")]
        public int? Key { get; set; }

        [JsonProperty("accuracy")]
        public int? Accuracy { get; set; }
    }

    public class PlayerPenalty
    {
        [JsonProperty("won")]
        public object Won { get; set; }

        [JsonProperty("commited")]
        public object Commited { get; set; }

        [JsonProperty("scored")]
        public int? Scored { get; set; }

        [JsonProperty("missed")]
        public int? Missed { get; set; }

        [JsonProperty("saved")]
        public object Saved { get; set; }
    }

    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("birth")]
        public PlayerBirth Birth { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("injured")]
        public bool Injured { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }
    }

    public class PlayerRequestFile
    {
        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("statistics")]
        public List<PlayerStatistic> Statistics { get; set; }
    }

    public class PlayerRoot
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        [JsonProperty("parameters")]
        public PlayerParameters Parameters { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("paging")]
        public PlayerPaging Paging { get; set; }

        [JsonProperty("response")]
        public List<PlayerRequestFile> Response { get; set; }
    }

    public class PlayerShots
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("on")]
        public int? On { get; set; }
    }

    public class PlayerStatistic
    {
        [JsonProperty("team")]
        public PlayerTeam Team { get; set; }

        [JsonProperty("league")]
        public PlayerLeague League { get; set; }

        [JsonProperty("games")]
        public PlayerGames Games { get; set; }

        [JsonProperty("substitutes")]
        public PlayerSubstitutes Substitutes { get; set; }

        [JsonProperty("shots")]
        public PlayerShots Shots { get; set; }

        [JsonProperty("goals")]
        public PlayerGoals Goals { get; set; }

        [JsonProperty("passes")]
        public PlayerPasses Passes { get; set; }

        [JsonProperty("tackles")]
        public PlayerTackles Tackles { get; set; }

        [JsonProperty("duels")]
        public PlayerDuels Duels { get; set; }

        [JsonProperty("dribbles")]
        public PlayerDribbles Dribbles { get; set; }

        [JsonProperty("fouls")]
        public PlayerFouls Fouls { get; set; }

        [JsonProperty("cards")]
        public PlayerCards Cards { get; set; }

        [JsonProperty("penalty")]
        public PlayerPenalty Penalty { get; set; }
    }

    public class PlayerSubstitutes
    {
        [JsonProperty("in")]
        public int? In { get; set; }

        [JsonProperty("out")]
        public int? Out { get; set; }

        [JsonProperty("bench")]
        public int? Bench { get; set; }
    }

    public class PlayerTackles
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("blocks")]
        public int? Blocks { get; set; }

        [JsonProperty("interceptions")]
        public int? Interceptions { get; set; }
    }

    public class PlayerTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
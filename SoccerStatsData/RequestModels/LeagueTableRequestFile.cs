using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStatsData.RequestModels
{
   
    public class LeagueTable
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

        [JsonProperty("standings")]
        public List<List<TeamStanding>> Standings { get; set; }
    }
    public class TeamStanding
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public LeagueTableTeam Team { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goalsDiff")]
        public int GoalsDiff { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        // needs reversing
        [JsonProperty("form")]
        public string Form { get; set; }

        [NotMapped]
        public char[] FormChars { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("all")]
        public LeagueTableStats All { get; set; }

        [JsonProperty("home")]
        public LeagueTableStats Home { get; set; }

        [JsonProperty("away")]
        public LeagueTableStats Away { get; set; }

        [JsonProperty("played")]
        public string Update { get; set; }
    }

    public class LeagueTableTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
    public class LeagueTableGoals
    {
        [JsonProperty("for")]
        public int For { get; set; }
        [JsonProperty("against")]
        public int Against { get; set; }
    }
    public class LeagueTableStats
    {
        [JsonProperty("played")]
        public int Played { get; set; }
        [JsonProperty("win")]
        public int Win { get; set; }
        [JsonProperty("draw")]
        public int Draw { get; set; }
        [JsonProperty("lose")]
        public int Lose { get; set; }
        [JsonProperty("goals")]
        public LeagueTableGoals Goals { get; set; }
    }
    

    public class LeagueTableResponse
    {
        [JsonProperty("league")]
        public LeagueTable League { get; set; }
    }

    public class LeagueTableRoot
    {
        [JsonProperty("response")]
        public List<LeagueTableResponse> Response { get; set; }
    }


}

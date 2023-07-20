using SoccerStatsData;

namespace SoccerStatsNew.Models
{
    public class LeagueData
    {
        public LeagueData(LeagueModel id, string year)
        {
            Id = id;
            Year = year;
        }
        public LeagueModel Id { get; set; }
        public string Year { get; set; }
    }
}

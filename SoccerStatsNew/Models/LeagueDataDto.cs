using SoccerStatsData;

namespace SoccerStatsNew.Models
{
    public class LeagueDataDto
    {
        public LeagueModel League { get; set; }
        public SeasonModel Season { get; set; }

        public LeagueDataDto(LeagueModel id, SeasonModel year)
        {
            League = id;
            Season = year;
        }
       
    }
}

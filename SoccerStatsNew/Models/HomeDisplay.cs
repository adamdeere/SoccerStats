using SoccerStatsData;

namespace SoccerStatsNew.Models
{
    /// <summary>
    /// pretty sure this is dead code
    /// </summary>
    public class HomeDisplay
    {
        public IEnumerable<CountryModel>? CountryList { get; set; }
        public IEnumerable<LeagueModel>? LeagueList { get; set; }

        public IEnumerable<string>? CountryNames { get; set; }
    }
}
using SoccerStatsData;

//
namespace SoccerStatsNew.Models
{/// <summary>
/// pretty sure this is dead code
/// </summary>
    public class TeamPageDisplay
    {
        public List<TeamsPage>? TeamsModelList { get; set; } = new List<TeamsPage>();
        public List<TeamVenue>? VenueModelList { get; set; } = new List<TeamVenue>();
        public IEnumerable<SeasonModel>? SeasonModelList { get; set; }
    }
}
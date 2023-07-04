using SoccerStatsData;

namespace SoccerStatsNew.Models
{
    public class TeamPageDisplay
    {
        public List<TeamsPage>? TeamsModelList { get; set; } = new List<TeamsPage>();
        public List<TeamVenue>? VenueModelList { get; set; } = new List<TeamVenue>();
        public IEnumerable<SeasonModel>? SeasonModelList { get; set; }
    }
}

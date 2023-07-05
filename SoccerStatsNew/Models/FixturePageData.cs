namespace SoccerStatsNew.Models
{
    public class FixturePageData
    {
        public DateTime Date { get; set; }
        public int FixtureId { get; set; }
        public string League { get; set; }
        public string LeagueLogo { get; set; }
        public string HomeTeam { get; set; }
        public string HomeTeamLogo { get; set; }
        public string AwayTeam { get; set; }
        public string AwayTeamLogo { get; set; }
    }
}

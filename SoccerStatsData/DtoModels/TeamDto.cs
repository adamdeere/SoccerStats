namespace SoccerStatsData.DtoModels
{
    public class TeamDto
    {
        public TeamResponse TeamModel { get; set; }

        public string? Season { get; set; }

        public int League { get; set; }

        public TeamDto(TeamResponse team, string season)
        {
            TeamModel = team;
            Season = season;
        }
    }
}

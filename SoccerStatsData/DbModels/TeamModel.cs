using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerStatsData
{
    public class TeamModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? TeamId { get; set; }

        public int? StadiumId { get; set; }

        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public int? Founded { get; set; }
        public bool? National { get; set; }
        public string? Logo { get; set; }
        public int? LeagueId { get; set; }

        //can use league Id as a foreign key for league data
    }
}
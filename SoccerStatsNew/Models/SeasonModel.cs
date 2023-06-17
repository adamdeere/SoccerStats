using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoccerStatsNew.Models
{
    public class SeasonModel
    {
        // GUID primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SeasonId { get; set; }
        //League Id
        public int Id { get; set; }

        [ForeignKey("Id")]
        public LeagueModel League { get; set; }
        public string CountryCode { get; set; }
        // Country code id
        [ForeignKey("CountryCode")]
        public CountryModel Country { get; set; }
        public int Year { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Standings { get; set; }
        public bool Players { get; set; }
        public bool TopScorers { get; set; }
        public bool TopAssists { get; set; }
        public bool TopCards { get; set; }
        public bool Injuries { get; set; }
        public bool Predictions { get; set; }
        public bool Odds { get; set; }
    }
}

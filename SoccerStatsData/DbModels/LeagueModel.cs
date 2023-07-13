using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerStatsData
{
    public class LeagueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LeagueId { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string LogoURL { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        [ForeignKey("CountryName")]
        public CountryModel Country { get; set; }

        public IEnumerable<SeasonModel>? Seasons { get; set; }// = new List<SeasonModel>();
    }
}
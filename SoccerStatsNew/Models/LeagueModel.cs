using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoccerStatsNew.Models
{
    public class LeagueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LogoURL { get; set; }
        public string CountryCode { get; set; }

        [ForeignKey("CountryCode")]
        public CountryModel Country { get; set; }
    }
}

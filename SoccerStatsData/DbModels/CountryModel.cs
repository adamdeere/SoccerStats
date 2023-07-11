using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerStatsData
{
    public class CountryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Name { get; set; }

        public string? CountryCode { get; set; }
        public string? FlagURL { get; set; }

        [NotMapped]
        public List<string> CountryNames { get; set; } = new List<string>();
    }
}
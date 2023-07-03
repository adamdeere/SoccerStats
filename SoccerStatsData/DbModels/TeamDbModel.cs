using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerStatsData
{
    public class TeamDbModel
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
    }
}
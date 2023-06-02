using System.ComponentModel.DataAnnotations;

namespace SoccerStats.Models
{
    public class CountryModel
    {
        [Key]
        public string? Id { get; set; }

        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public string? Flag { get; set; }
    }
}
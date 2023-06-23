using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeApp.Models
{
    public class LocationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Location")]
        public string LocationId { get; set; }

        public float Length { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public ICollection<ItemLocationModel> ItemLocations { get; set; } = new List<ItemLocationModel>();
    }
}
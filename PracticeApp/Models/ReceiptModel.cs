using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeApp.Models
{
    public class ReceiptModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GRN { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expected arrival")]
        public DateTime ExpectedArrival { get; set; }

        [Display(Name = "Total weight")]
        public float TotalWeight { get; set; }

        [Display(Name = "Total cube")]
        public float TotalCube { get; set; }

        public ICollection<ItemModel> ReceiptItems { get; set; } = new List<ItemModel>();
    }
}
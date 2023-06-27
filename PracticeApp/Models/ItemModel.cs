using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeApp.Models
{
    public class ItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemNo { get; set; }

        public int GRN { get; set; }

        [ForeignKey("GRN")]
        public ReceiptModel? Receipt { get; set; }

        public float Quantity { get; set; }

        [Display(Name = "SKU Code")]
        public string SKUCode { get; set; }

        [ForeignKey("SKUCode")]
        public ProductModel? Product { get; set; }

        [Display(Name = "Storage location")]
        public string? LocationId { get; set; }

        // change this to a list of locations
        [ForeignKey("LocationId")]
        public LocationModel? Location { get; set; }
    }
}
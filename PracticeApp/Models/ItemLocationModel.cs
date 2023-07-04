using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeApp.Models
{
    public class ItemLocationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Location Id")]
        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationModel? Location { get; set; }

        [Display(Name = "GRN Code")]
        public int GRN { get; set; }

        [ForeignKey("GRN")]
        public ReceiptModel? Receipt { get; set; }

        [Display(Name = "Item Number")]
        public int ItemNo { get; set; }

        [ForeignKey("ItemNo")]
        public ItemModel? Item { get; set; }

        [Remote(action: "CheckMaxQTY", controller: "ItemLocation", AdditionalFields = nameof(ItemNo))]
        public float Quantity { get; set; }
    }
}
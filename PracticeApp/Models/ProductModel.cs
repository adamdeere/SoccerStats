using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeApp.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "SKU Code")]
        public string SKUCode { get; set; }

        public string? Description { get; set; }

        public float Length { get; set; }

        public float Height { get; set; }

        public float Width { get; set; }

        public float Weight { get; set; }

        public List<ItemModel>? Items { get; set; } = new List<ItemModel>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual Register? Register { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductType { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductBrand { get; set; }
        [Required]
        public string ProductImage { get; set; }
        public string AdditonalProductImage1 { get; set; }
        public string AdditonalProductImage2 { get; set; }
        [Required]
        public int ProductPrice { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductDescription { get; set; }

        [Required]
        public int ShippingCost { get; set; }

        [Required]
        public int ProductQuantity { get; set; }
        public float Rating { get; set; }
        public int NoOfRatings { get; set; }

    }
}

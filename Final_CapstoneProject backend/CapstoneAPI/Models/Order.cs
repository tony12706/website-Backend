using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual Register? Register { get; set; }
        [Required]
        public string SellerEmailId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductType { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(100)]
        public string ProductBrand { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public int ProductPrice { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductDescription { get; set; }

        [Required]
        public int ShippingCost { get; set; }

        [Required]
        public int QuantityPurchased { get; set; }

        [Required]
        public int TotalPrice { get; set; }
        public string DeliveryStatus { get; set; }
        public bool ReturnStatus { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CapstoneAPI.Models
{
    public class Wishlist
    {
        [Key]
        public int WishListId { get; set; }
        public string? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual Register? Register { get; set; }
        [Required]
        public string SellerEmailId { get; set; }
        [Required]
        public int ProductId { get; set; }
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
    }
}

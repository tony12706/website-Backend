using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneAPI.Models
{
    public class Register
    {
        [StringLength(100)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmailId { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
        [StringLength(30)]
        [Required]
        public string Country { get; set; }
        [Required]
        public long MobNo { get; set; }
        [StringLength(30)]
        public string Company { get; set; }
        [StringLength(120)]
        public string WebsiteUrl { get; set; }
        [Required]
        [StringLength(300)]
        public string ResidenceAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; }
        [Required]
        [StringLength(200)]
        public string SecurityQuestion { get; set; }

        [Required]
        [StringLength(30)]
        public string SecurityAnswer { get; set; }

        [NotMapped]
        public virtual ICollection<Address> Address { get; set; }
        [NotMapped]
        public virtual ICollection<Product> Product { get; set; }
        [NotMapped]
        public virtual ICollection<DeliveryPincode> DeliveryPincode { get; set; }
        [NotMapped]
        public virtual ICollection<Order> Order { get; set; }
        [NotMapped]
        public virtual ICollection<Cart> Cart { get; set; }
        [NotMapped]
        public virtual ICollection<Wishlist> Wishlist { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneAPI.Models
{
    public class DeliveryPincode
    {
        [Key]
        public int PId { get; set; }
        [Required]

        public int PinCode { get; set; }
        [Required]
        public string? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual Register? Register { get; set; }

    }
}

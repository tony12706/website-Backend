using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneAPI.Models
{
    public class Address
    {
        [Key]
        public int AddrId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public long PhoneNo { get; set; }
        [Required]
        [StringLength(300)]
        public string FullAddress { get; set; }
        [Required]
        public int PinCode { get; set; }

        [StringLength(100)]
        public string AddrType { get; set; }

        public string? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual Register? Register { get; set; }

    }
}

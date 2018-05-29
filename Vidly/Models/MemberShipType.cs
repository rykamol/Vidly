using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonth { get; set; }

        public byte DiscountRate { get; set; }
    }
}
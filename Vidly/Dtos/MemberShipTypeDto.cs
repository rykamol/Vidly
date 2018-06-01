using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MemberShipTypeDto
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
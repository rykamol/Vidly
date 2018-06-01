using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

        public MemberShipTypeDto MemberShipTypeDto { get; set; }

        [Required(ErrorMessage = "Membership is required.")]
        public byte MemberShipTypeId { get; set; }
    }
}
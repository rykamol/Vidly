using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        public byte MemberShipTypeId { get; set; }
    }
}
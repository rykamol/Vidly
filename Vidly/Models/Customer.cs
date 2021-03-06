﻿using System;
using System.ComponentModel.DataAnnotations;
using Vidly.CustomValidators;

namespace Vidly.Models
{
    public class Customer
    {
        public Customer()
        {
            Id = 0;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Membership is required.")]
        public byte MemberShipTypeId { get; set; }
    }
}
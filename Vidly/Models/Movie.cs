using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Realease Date")]
        public DateTime RealeaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Adding Date")]
        public DateTime AddedDate { get; set; }

        [Required]
        [Range(1, 30)]
        [Display(Name = "Number Of Stock")]
        public int NumberInStoke { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

    }
}
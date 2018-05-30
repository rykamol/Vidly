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
        public DateTime RealeaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public int NumberInStoke { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public int GenreId { get; set; }

    }
}
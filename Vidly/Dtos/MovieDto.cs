using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
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
        [Range(1, 30)]
        [Display(Name = "Number Of Stock")]
        public int NumberInStoke { get; set; }

        public GenreDto GenreDto { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}
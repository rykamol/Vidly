using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public NewMovieViewModel()
        {
            Id = 0;
        }

        public NewMovieViewModel(NewMovieViewModel viewModel)
        {
            Id = viewModel.Id;
            GenreId = viewModel.GenreId;
            Name = viewModel.Name;
            RealeaseDate = viewModel.RealeaseDate;
            NumberInStoke = viewModel.NumberInStoke;
        }

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

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie() {Id = 1, Name = "Blood Diamond"},
                new Movie() {Id = 2, Name = "Titanic"}
            };
            return View(movies);
        }
    }
}
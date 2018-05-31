﻿using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View(_context.Movies.Include(x => x.Genre).ToList().ToList());
        }

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel()
            {
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(NewMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewData = new NewMovieViewModel()
                {
                    Movie = viewModel.Movie,
                    Genres = _context.Genres
                };
                return View("MovieForm", viewData);
            }

            if (viewModel.Movie.Id == 0)
                _context.Movies.Add(Mapper.Map<Movie>(viewModel));
            else
            {
                var movie = _context.Movies.Include(x => x.Genre).Single(x => x.Id == viewModel.Movie.Id);
                Mapper.Map(viewModel, movie);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id < 0)
                return HttpNotFound();

            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            if (id < 0)
                return HttpNotFound();

            var movie = _context.Movies.Include(x => x.Genre).Single(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }
    }
}
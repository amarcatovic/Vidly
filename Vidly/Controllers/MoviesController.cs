using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public object Role { get; private set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            var model = new NewMovieViewModels
            {
                Genres = _context.Genres.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(NewMovieViewModels nm)
        {
            if(!ModelState.IsValid)
            {
                var moviee = new Movie
                {
                    Id = nm.Id,
                    GenreId = (int)nm.GenreId,
                    InStock = (int)nm.InStock,
                    ReleaseDate = (DateTime)nm.ReleaseDate,
                    Name = nm.Name

                };
                var model = new NewMovieViewModels(moviee)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("New", model);
            }

            var movie = new Movie();
            movie.Name = nm.Name;
            movie.ReleaseDate = (DateTime)nm.ReleaseDate;
            movie.GenreId = (int)nm.GenreId;
            movie.InStock = (int)nm.InStock;
            if (nm.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
               movie = _context.Movies.Single(m => m.Id == nm.Id); 
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var model = new NewMovieViewModels(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("New", model);
        }
        public ActionResult Index()
        {
            if(User.IsInRole(RoleNames.CanManageMovies))
                return View("Index");
            return View("ReadOnlyIndex");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(element => element.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}
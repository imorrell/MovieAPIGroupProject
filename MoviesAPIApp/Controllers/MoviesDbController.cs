using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesAPIApp.Models;

namespace MoviesAPIApp.Controllers
{
    public class MoviesDbController : Controller
    {
        private readonly MoviesDbContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public MoviesDbController(MoviesDbContext context)
        {

            _context = context;
        }

        public IActionResult DisplayFavoriteMovies()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_context.AspNetUsers.Where(x => x.Id == id) != null)
            {
                return View(_context.FavoriteMovies.Where(tasks => tasks.UserId == id).ToList());
            }
            _context.FavoriteMovies.ToList();
            return View();
        }
        

        public IActionResult AddToFavorites(Search searchObject)
        {
            //determine the user
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Id = id;

            //create favorite movie object
            FavoriteMovies movie = new FavoriteMovies
            {
                //assign properties from the search to the movie object

                Title = searchObject.Title,
                Year = searchObject.Year,
                Type = searchObject.Type,
                UserId = id
            };

            _context.FavoriteMovies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("DisplayFavoriteMovies");
        }

        public IActionResult DeleteMovie(int id)
        {
            var foundMovie = _context.FavoriteMovies.Find(id);
            if (foundMovie != null)
            {
                _context.Remove(foundMovie);
                _context.SaveChanges();
            }
            return RedirectToAction("DisplayFavoriteMovies");
        }

    }
}
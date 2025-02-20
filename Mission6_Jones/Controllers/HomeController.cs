using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Jones.Models;
using SQLitePCL;

namespace Mission6_Jones.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList(); // Provide options for the dropdown
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation");
            }
            else // Invalid data
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList(); // Return ViewBag if data is invalid
                return View(response);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies
                                 .Include(x => x.Category)
                                 .Where(m => m.Title != null && m.Title != string.Empty)
                                 .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id); // This passes the specific record to the view
            // ViewBag is a way to send data from the controller to the view, especially if it isn't part of the given model
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList(); // We have to make sure to send over the categories as well!
            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            _context.Update(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id); // Passes specific record to delete
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie response, int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}

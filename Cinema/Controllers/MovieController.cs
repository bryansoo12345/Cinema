using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> objMovieList = _db.Movie.ToList();
            //IEnumerable<Movie> objMovieList = _db.Movie.Where(x=>x.Genre== "Thriller");
            return View(objMovieList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Movie movie = new Movie();
            return PartialView("_MovieModelPartial", movie);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.IFormPhoto != null && movie.IFormPhoto.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        movie.IFormPhoto.CopyTo(memoryStream);
                        movie.CoverPhoto = memoryStream.ToArray(); // Assuming PhotoData is a byte[] property in your Movie model
                    }
                }
                _db.Movie.Add(movie);
                _db.SaveChanges();
                return Json(new { success = true, message = "Movie created successfully", movieId = movie.Id });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors });

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }

            var movie = _db.Movie.FirstOrDefault(x => x.Id == id);

            if(movie == null)
            {
                return NotFound();
            }

            return PartialView("_MovieModelPartial", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            _db.Movie.Update(movie);
            //_db.Movie.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

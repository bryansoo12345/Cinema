using Cinema.Data;
using Cinema.Models;
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

        #region Customer UI

        public IActionResult Movie()
        {
            IEnumerable<Movie> objMovieList = _db.Movie.ToList();
            return View(objMovieList);
        }

        #endregion

        #region Manage Movie

        public IActionResult ManageMovie()
        {
            IEnumerable<Movie> objMovieList = _db.Movie.ToList();
            return View(objMovieList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Movie movie = new Movie();
            string methodName = nameof(Create); // Get the name of the method dynamically
            ViewBag.MethodName = methodName;
            return PartialView("_MovieModelPartial", movie);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                SaveImageFile(movie);
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
            string methodName = nameof(Edit); 
            ViewBag.MethodName = methodName;
            return PartialView("_MovieModelPartial", movie);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                var movieToUpdate = _db.Movie.FirstOrDefault(m => m.Id == movie.Id);

                if (movieToUpdate != null)
                {
                    // Update the properties of the entity
                    movieToUpdate.Name = movie.Name;
                    movieToUpdate.Description = movie.Description;
                    movieToUpdate.Genre = movie.Genre;
                    if (movie.IFormPhoto != null && movie.IFormPhoto.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            movie.IFormPhoto.CopyTo(memoryStream);
                            movieToUpdate.CoverPhoto = memoryStream.ToArray();
                        }
                    }
                    //_db.Movie.Update();
                    // Save changes to the database
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Movie edited successfully", movieId = movie.Id });
                }
                
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors });
        }

        public void SaveImageFile(Movie movie)
        {
            if (movie.IFormPhoto != null && movie.IFormPhoto.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    movie.IFormPhoto.CopyTo(memoryStream);
                    movie.CoverPhoto = memoryStream.ToArray(); 
                }
            }
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Movie.Find(id);
            if (obj == null)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, errors });
            }

            _db.Movie.Remove(obj);
            _db.SaveChanges();
            return Json(new { success = true, message = "Movie edited successfully", movieId = id });

        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _db.Movie.ToList();
            return PartialView("_MovieListManage", movies);
        }

        #endregion


        #region BookMovie

        public IActionResult BookMovie()
        {
            MovieHall? movieHall = _db.MovieHall.FirstOrDefault();

            movieHall.ShowingMovies = _db.Movie.Where(x => x.Genre == "Thriller").Take(5).ToList();
            movieHall.Seats = MovieHall.PopulateSeats(movieHall.NumberOfRows, movieHall.NumberOfSeats).OrderBy(x=>x.SeatCode);
            return View(movieHall);
        }

        #endregion

    }
}
    
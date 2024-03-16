using Cinema.Data;
using Cinema.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
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

        public IActionResult Cinemas()
        {
            IEnumerable<CinemaBranch> objCinemaList = _db.CinemaBranch.ToList();
            return View(objCinemaList);
        }


        [HttpGet]
        public IActionResult BuyTicket(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Movie.BuyTicketViewModel buyTicketViewModel = new Movie.BuyTicketViewModel();
            buyTicketViewModel.CinemaBranch = _db.CinemaBranch.FirstOrDefault(x => x.Id == id);
            buyTicketViewModel.MovieShows = _db.MovieShow.Where(x => x.MallCode == buyTicketViewModel.CinemaBranch.MallCode).ToList();
            foreach (var x in buyTicketViewModel.MovieShows)
            {
                x.Movie = _db.Movie.Where(y => y.MovieCode == x.MovieCode).FirstOrDefault();
                x.MovieShowTimes = _db.MovieShowTimes.Where(y => y.MovieShowTimeCode == x.MovieShowTimeCode).ToList();
            }

            if (buyTicketViewModel.CinemaBranch == null || buyTicketViewModel.CinemaBranch == null)
            {
                return NotFound();
            }
            return View("BuyTicket", buyTicketViewModel);
        }
        //Good Practice: Pass simple and non sensitive data through parameters to reduce interactions with database.


        [HttpGet]
        public IActionResult BookMovie(string ShowCode, string HallCode, string MovieName)
        {
            MovieShowTime.BookMovieViewModel BookMovieViewModel = new MovieShowTime.BookMovieViewModel();
            // Use ShowCode to get MovieHall From DB. 
            BookMovieViewModel.MovieShowSeats = _db.MovieShowSeats.Where(x => x.MovieShowTimeCode == ShowCode).ToList();
            BookMovieViewModel.MovieShowTime = _db.MovieShowTimes.Where(x=>x.MovieShowTimeCode==ShowCode).FirstOrDefault();
            return View(BookMovieViewModel);
        }

        [HttpPost]
        public IActionResult ConfirmBookMovie(MovieShowTime.BookTicketModel BookMovie)
        {
            List<MovieShowSeats> mMovieShowSeats = _db.MovieShowSeats.Where(x => x.MovieShowTimeCode == BookMovie.MovieShowTimeCode).ToList();

            if (mMovieShowSeats != null && mMovieShowSeats.Any())
            {
                // Update IsBooked for the desired seats
                foreach (var seat in mMovieShowSeats.Where(s => BookMovie.DesiredSeats.Contains(s.SeatCode)))
                {
                    seat.IsBooked = true;
                }

                // Save changes to database
                _db.SaveChanges();

                return Json(new { success = true, message = "Movie booked successfully" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors });
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
            ModelState.Remove("MovieCode");
            if (ModelState.IsValid)
            {
                movie.MovieCode = "MV" + movie.Genre.ToString().Substring(0, 2) + "01";
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
                            movieToUpdate.PhotoFile = memoryStream.ToArray();
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
                    movie.PhotoFile = memoryStream.ToArray(); 
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


        #region Manage Cinema Movie Show

        [HttpPost]
        public IActionResult ConfirmShowTime(MovieShowTime.SetShowTimeModel movieShow)
        {
            List<MovieShowSeats> movieShowSeats = new List<MovieShowSeats>();
            //string ShowCode = movieShow.HallCode + "-B1";
            MovieHall? movieHall = _db.MovieHall.FirstOrDefault();
            foreach (var x in movieShow.SeatCodes)
            {
                if (!string.IsNullOrEmpty(x))
                {
                    
                    movieShowSeats.Add(new MovieShowSeats
                    {
                        MovieShowTimeCode = movieShow.MovieShowTimeCode,
                        SeatCode = x,
                        IsBooked = false 
                    });
                }
            }
            _db.MovieShowSeats.AddRange(movieShowSeats);
            _db.SaveChanges();
            return Json(new { success = true, message = "Movie show created successfully"});
        }

        //[HttpGet]
        ////Good Practice: Pass simple and non sensitive data through parameters to reduce interactions with database.
        ////This method is to for admin/cinema users to set show time. the ui will allow admin to select movie, select hall, then initliaze the cinema hall for showtime.
        //public IActionResult SetShowTime(string ShowCode, string HallCode, string MovieName)
        //{
        //    // Use ShowCode to get MovieHall From DB. 
        //    MovieHall? MovieHall = _db.MovieHall.Where(x => x.MovieShowTimeCode == ShowCode).FirstOrDefault();
        //    MovieHall.MovieName = MovieName;
        //    MovieHall.HallCode = HallCode;
        //    MovieHall.Seats = MovieHall.PopulateSeats(MovieHall.NumberOfRows, MovieHall.NumberOfSeats);
        //    return View(MovieHall);
        //}

        #endregion

    }
}
    
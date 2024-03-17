using Cinema.Data;
using Cinema.Models.UserAccounts;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models.AdminPanel;
using Cinema.Models.Utilities;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult AdminPanel()
        {
            AdminPanel AdminPanelViewModel = new AdminPanel();
            AdminPanelViewModel.Movie = _db.Movie.Take(3).ToList();

            return View(AdminPanelViewModel);
        }

        public IActionResult MovieHall()
        {
            IEnumerable<MovieHall> MovieHall = _db.MovieHall.Where(x=>x.MallCode==LoginInfo.BranchCode).ToList();

            return View(MovieHall);
        }
        [HttpGet]
        public IActionResult AddMovieHall()
        {
            MovieHall MovieHall = new MovieHall();
            string methodName = nameof(AddMovieHall);
            ViewBag.MethodName = methodName;
            ViewData["Title"] = "Add Movie Hall";
            return PartialView("_ManageMovieHallPartial", MovieHall);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddMovieHall(MovieHall movieHall)
        {
            ModelState.Remove("MallCode");
            movieHall.MallCode = LoginInfo.BranchCode;
            movieHall.HallCode = $"{LoginInfo.BranchCode}{Utility.GenerateString(3)}{movieHall.SelHallCode}";
            movieHall.MallName = _db.CinemaBranch.Where(x => x.MallCode == LoginInfo.BranchCode).Select(x => x.MallName).FirstOrDefault();
            _db.MovieHall.Add(movieHall);
            _db.SaveChanges();
            return Json(new { success = true, message = "Movie hall added successfully", movieId = movieHall.Id });
            //var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            //return Json(new { success = false, errors });

        }


        #region Manage Cinema Hall -> Lead into Manage Movie Show filter by Date order by ShowTime 

        [HttpGet]
        public IActionResult ManageHall(string HallCode)
        {
            var movieHall = _db.MovieHall.FirstOrDefault(x => x.HallCode == HallCode);

            if (movieHall == null)
            {
                return NotFound();
            }
            //MovieHall MovieHall = new MovieHall();
            string methodName = nameof(ManageHall);
            ViewBag.MethodName = methodName;
            ViewData["Title"] = "Add Movie Hall";
            return View(movieHall);
        }

        #endregion

        #region Old Design - Manual Partial View

        //Dynamic Partial View
        [HttpGet]
        public IActionResult LoadPartial(string partial)
        {
            try
            {
                string? typeName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".Models." + partial;

                Type? entityType = Type.GetType(typeName);

                if (entityType == null)
                {
                    return PartialView($"_{partial}");
                }
                else
                {
                    //Dynamic Rendering
                    string entitySetName = _db.Model.FindEntityType(entityType).GetTableName();

                    var dbSetProperty = _db.GetType().GetProperty(entitySetName);

                    var dbSet = dbSetProperty.GetValue(_db);

                    IEnumerable<object> entityList = (IEnumerable<object>)dbSet;

                    //Process
                    //IEnumerable<object> processedEntities = ProcessEntities(entityList, entityType);

                    return PartialView($"{partial}", entityList);
                }

            }
            catch (Exception)
            {
                throw new Exception("Error, Please contact your administrator!");
            }

        }

        private IEnumerable<object> ProcessEntities(IEnumerable<object> entities, Type entityType)
        {
            return entityType switch
            {
                var type when type == typeof(MovieHall) => entities.Cast<MovieHall>()
                    .OrderBy(x => x.ExternalCode.Substring(0, 1))
                    .ThenBy(x => int.Parse(x.ExternalCode.Substring(1)))
                    .Cast<object>(),

                var type when type == typeof(Movie) => entities.Cast<Movie>()
                    .OrderByDescending(x => x.MovieCode)
                    .Cast<object>(),

                _ => entities
            };
        }

        #endregion

    }
}

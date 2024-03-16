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

        //Dynamic Partial View
        [HttpGet]
        public IActionResult LoadPartial(string partial)
        {
            try
            {
                // Get the fully qualified type name including the namespace
                string? typeName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".Models." + partial; 

                Type? entityType = Type.GetType(typeName);

                if (entityType == null)
                {
                    return PartialView($"_{partial}");
                }
                else
                {
                    // Get the property name of the entity set in the DbContext
                    string entitySetName = _db.Model.FindEntityType(entityType).GetTableName();

                    // Get the DbSet property dynamically using reflection
                    var dbSetProperty = _db.GetType().GetProperty(entitySetName);

                    // Get the value of the DbSet property
                    var dbSet = dbSetProperty.GetValue(_db);

                    IEnumerable<object> entityList = (IEnumerable<object>)dbSet;

                    // Pass entityList to the PartialView
                    return PartialView($"{partial}", entityList);
                }

            }
            catch (Exception)
            {
                throw new Exception("Error, Please contact your administrator!");
            }

        }

        #region Manage Cinema Hall -> Lead into Manage Movie Show filter by Date order by ShowTime 

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
            movieHall.MallName = _db.CinemaBranch.Where(x => x.MallCode==LoginInfo.BranchCode).Select(x => x.MallName).FirstOrDefault();
            _db.MovieHall.Add(movieHall);
            _db.SaveChanges();
            return Json(new { success = true, message = "Movie hall added successfully", movieId = movieHall.Id });
            //var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            //return Json(new { success = false, errors });

        }

        #endregion

    }
}

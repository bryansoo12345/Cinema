using Cinema.Data;
using Cinema.Models;
using Cinema.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> objMovieList = _db.Movie.Take(1).ToList();

            //Dev
            LoginInfo.SetLoginInfo("BranchManager", "pc1", "8ODW02");
            //Branch Manager
            LoginInfo.SetBranchManager("PC");

            return View(objMovieList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
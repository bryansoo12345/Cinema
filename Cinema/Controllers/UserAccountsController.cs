using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class UserAccountsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserAccountsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {   
            IEnumerable<UserAccounts> UserAccountsList = _db.UserAccounts.ToList();
            return View(UserAccountsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserAccounts userAccounts)
        {
            if (ModelState.IsValid)
            {
                _db.UserAccounts.Add(userAccounts);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

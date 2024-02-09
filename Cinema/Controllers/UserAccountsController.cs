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

        public IActionResult UserAccounts()
        {   
            IEnumerable<Account> UserAccountsList = _db.Account.ToList();
            return View(UserAccountsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account userAccounts)
        {
            if (ModelState.IsValid)
            {
                _db.Account.Add(userAccounts);
                _db.SaveChanges();
                return RedirectToAction("UserAccounts");
            }
            return View();
        }
    }
}

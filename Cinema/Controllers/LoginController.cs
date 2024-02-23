using Microsoft.AspNetCore.Mvc;
using Cinema.Data;
using Cinema.Models;
using Cinema.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Cinema.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Account LoginAttempt)
        {

            try
            {
                var user = _db.Account.FirstOrDefault(x => x.Email == LoginAttempt.Email);

                // Check if a user with the provided email exists and if the password matches
                if (user != null && VerifyPassword(user.Password, LoginAttempt.Password))
                {
                    // Authentication successful
                    LoginInfo.RoleType = user.AccountType;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Wrong Password
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    throw new Exception("Wrong Password");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Login");
            }

        }
        private bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            // Implement your password verification logic here
            // For example, you might use hashing and salting techniques
            // Here's a simple example assuming plain text passwords
            return hashedPassword == enteredPassword;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Cinema.Data;
using Cinema.Models;
using Cinema.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using static Cinema.Models.Account;

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
                var user = _db.Account.FirstOrDefault(x => x.UserName == LoginAttempt.UserName);

                if (user != null && Security.VerifyPassword(user.Password, LoginAttempt.Password))
                {
                    LoginInfo.SetLoginInfo(user.AccountType, user.UserName, user.UserToken);

                    //Check if its BranchManager
                    if(!string.IsNullOrEmpty(LoginInfo.RoleType) && LoginInfo.RoleType == AccountTypeSelections.BranchManager.ToString())
                    {
                        string branchToken = _db.BranchManager.Where(x=>x.UserToken==LoginInfo.UserToken).Select(y=>y.BranchCode).FirstOrDefault();
                        LoginInfo.SetBranchManager(branchToken);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    throw new Exception("Wrong Password");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Login");
            }

        }

    }
}

using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Cinema.Models.Utilities;
using static Cinema.Models.Account;
using Cinema.Models.UserAccounts;

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
            ModelState.Remove("UserToken");
            if (ModelState.IsValid)
            {
                userAccounts.Password = Security.HashPassword(userAccounts.Password);
                userAccounts.UserToken = Security.GenerateUniqueUserToken(_db, 6);

                if (string.IsNullOrEmpty(userAccounts.AccountType))
                {
                    throw new Exception("Please Contact Administrator");
                }

                if (userAccounts.AccountType == AccountTypeSelections.BranchManager.ToString())
                {
                    AssignBranchManager(userAccounts.UserToken, userAccounts.BranchCode);
                }

                _db.Account.Add(userAccounts);
                _db.SaveChanges();
                return RedirectToAction("UserAccounts");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetBranch()
        {
            var cinemaBranches = _db.CinemaBranch
                                .Select(branch => new { mallCode = branch.MallCode, mallName = branch.MallName })
                                .ToList();
            return Ok(cinemaBranches);
        }

        public void AssignBranchManager(string UserToken, string BranchCode)
        {
            BranchManager branchManager = new BranchManager
            {
                UserToken = UserToken, 
                BranchCode = BranchCode
            };
            _db.BranchManager.Add(branchManager);

        }

    }
}

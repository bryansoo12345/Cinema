using Cinema.Data;
using Cinema.Models;
using Cinema.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Cinema.Controllers
{
    public class CinemaBranchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CinemaBranchController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult CinemaBranch()
        {
            IEnumerable<CinemaBranch> CinemaBranchList = _db.CinemaBranch;
            return View(CinemaBranchList);
        }

        [HttpGet]
        public IActionResult CreateCinemaBranch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCinemaBranch(CinemaBranch cinemaBranch)
        {

            try
            {
                ModelState.Remove("MallCode");
                if (ModelState.IsValid)
                {
                    string? latestMallCode = _db.CinemaBranch.OrderByDescending(x => EF.Property<DateTime>(x, "CreatedDateTime")).Select(x => x.MallCode).FirstOrDefault();
                    if (!string.IsNullOrEmpty(latestMallCode))
                    {
                        // Extract the numeric portion from the latest MallCode
                        string numericPart = Regex.Replace(latestMallCode, "[^0-9]", ""); //Remove Characters

                        // Parse the numeric portion to an integer and increment it
                        if (int.TryParse(numericPart, out int numericValue))
                        {
                            numericValue++; // Increment the numeric value
                            string newNumericPart = numericValue.ToString().PadLeft(3, '0'); // Convert back to string and pad with leading zeros if necessary

                            // Construct the new MallCode
                            cinemaBranch.MallCode = latestMallCode.Substring(0, latestMallCode.Length - 3) + newNumericPart;
                            ImageUtility.SaveImageFile(cinemaBranch);
                            _db.CinemaBranch.Add(cinemaBranch);
                            _db.SaveChanges();
                            return RedirectToAction("CreateCinemaBranch");
                        }
                        else
                        {
                            throw new Exception("Please contact your administrator.");
                        }
                    }
                }
                return View();

            }
            catch (Exception ex)
            {
                throw new Exception("Error Creating Cinema");
            }

        }
        [HttpGet]
        public IActionResult BuyTicket()
        {
            return View();
        }
    }
}

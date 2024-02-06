using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class CinemaBranchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CinemaBranchController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CinemaBranch> CinemaBranchList = _db.CinemaBranch;
            return View(CinemaBranchList);
        }
    }
}

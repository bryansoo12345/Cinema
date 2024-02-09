using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        [HttpGet]
        public IActionResult LoadPartial(string partial)
        {
            try
            {
                // Get the fully qualified type name including the namespace
                string? typeName = "Cinema.Models." + partial; // Replace "YourNamespace" with the actual namespace of your type

                // Get the type of the entity you want to use
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
                    // Cast the result to IEnumerable<object> if needed
                    IEnumerable<object> entityList = (IEnumerable<object>)dbSet;

                    // Pass entityList to the PartialView
                    return PartialView($"_{partial}", entityList);
                }

            }
            catch (Exception)
            {
                throw new Exception("Error, Please contact your administrator!");
            }

        }
    }
}

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
                    //only add _ for shared modules, for example like _AdminPanelDashboard
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
    }
}

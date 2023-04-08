using Microsoft.AspNetCore.Mvc;

namespace Sundues_Employee_CRUD.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

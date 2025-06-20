using EmployeeManagementSystem.Application.Departments;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _context;

        public DepartmentController(IDepartmentService context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _context.GetAllDepartment();
            return View(departments);
        }


        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentVM department)
        {
            await _context.AddNewDepartmentAsync(department);
            return RedirectToAction("Index");
        }
    }
}

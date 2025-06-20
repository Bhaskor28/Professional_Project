using EmployeeManagementSystem.Application.Departments;
using EmployeeManagementSystem.Application.Employees;
using EmployeeManagementSystem.Application.Common.PaginatedList;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Domain.Entities;
namespace EmployeeManagementSystem.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
        {
            int pageSize = 5;
            var pagedEmployees = await _employeeService.GetPagedEmployeesAsync(searchString, sortOrder, pageNumber, pageSize);
            return View(pagedEmployees);
        }
        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {

            ViewBag.Departments = await _departmentService.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeVM employee)
        {

            await _employeeService.AddNewEmployeeAsync(employee);
            return RedirectToAction("Index");
        }

    }
}

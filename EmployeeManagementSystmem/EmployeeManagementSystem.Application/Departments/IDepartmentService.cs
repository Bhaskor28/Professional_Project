using EmployeeManagementSystem.Application.Employees;

namespace EmployeeManagementSystem.Application.Departments
{
    public interface IDepartmentService
    {
        Task AddNewDepartmentAsync(DepartmentVM department);
        Task<IEnumerable<DepartmentVM>> GetAllDepartment();

    }
}

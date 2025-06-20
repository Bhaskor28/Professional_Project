using EmployeeManagementSystem.Application.Common.PaginatedList;

namespace EmployeeManagementSystem.Application.Employees
{
    public interface IEmployeeService
    {
        Task AddNewEmployeeAsync(EmployeeVM employeeVM);
        Task<IEnumerable<EmployeeVM>> GetAllEmployees();
        Task<PaginatedList<EmployeeVM>> GetPagedEmployeesAsync(string? search, string? sortOrder, int pageNumber, int pageSize);

    }
}

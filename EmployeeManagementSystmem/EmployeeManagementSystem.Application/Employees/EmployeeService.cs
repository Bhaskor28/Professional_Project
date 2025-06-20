using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagementSystem.Application.Common.PaginatedList;
using EmployeeManagementSystem.Application.Repository;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Application.Employees
{

    public class EmployeeService : IEmployeeService
    {

        private readonly IBaseRepository<Employee> _employee;
        private readonly IMapper _mapper;

        public EmployeeService(IBaseRepository<Employee> employee, IMapper mapper)
        {
            _employee = employee;
            _mapper = mapper;
        }

        public async Task AddNewEmployeeAsync(EmployeeVM employeeVM)
        {
            var employee = _mapper.Map<Employee>(employeeVM);
            await _employee.AddAsync(employee);
        }
        async Task<IEnumerable<EmployeeVM>> IEmployeeService.GetAllEmployees()
        {
            var employees = await _employee.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeVM>>(employees);
        }

        public async Task<PaginatedList<EmployeeVM>> GetPagedEmployeesAsync(string? search, string? sortOrder, int pageNumber, int pageSize)
        {
            var query = _employee.GetQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.FirstName.ToLower().Contains(search.ToLower()));
            }
            query = sortOrder switch
            {
                "nameDesc" => query.OrderByDescending(e => e.FirstName),
                _ => query.OrderBy(e => e.FirstName),
            };
            var projectedQuery = query.ProjectTo<EmployeeVM>(_mapper.ConfigurationProvider);
            var pagedEmployees = PaginatedList<EmployeeVM>.Create(projectedQuery, pageNumber, pageSize);
            return await Task.FromResult(pagedEmployees);
        }
    }
}

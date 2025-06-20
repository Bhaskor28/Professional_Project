using AutoMapper;
using EmployeeManagementSystem.Application.Repository;
using EmployeeManagementSystem.Domain.Entities;
namespace EmployeeManagementSystem.Application.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IBaseRepository<Department> _department;
        private readonly IMapper _mapper;

        public DepartmentService(IBaseRepository<Department> department,IMapper mapper)
        {
            _department = department;
            _mapper = mapper;
        }

        public async Task AddNewDepartmentAsync(DepartmentVM newDepartment)
        {
            var department = _mapper.Map<Department>(newDepartment);
            await _department.AddAsync(department);
        }

        public async Task<IEnumerable<DepartmentVM>> GetAllDepartment()
        {
            var departments = await _department.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentVM>>(departments);
        }
    }
}

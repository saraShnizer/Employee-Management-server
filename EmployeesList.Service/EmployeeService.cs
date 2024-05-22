using EmployeesList.Core.Entities;
using EmployeesList.Core.Repositories;
using EmployeesList.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesList.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddAsync(Employee emp)
        {
            return await _employeeRepository.AddAsync(emp);
        }

        public async Task DeleteAsync(int empID)
        {
            await _employeeRepository.DeleteAsync(empID);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int empID)
        {
            return await _employeeRepository.GetByIdAsync(empID);
        }

        public async Task<IEnumerable<EmployeeRole>> GetRolesAsync(int empId)
        {
            return await _employeeRepository.GetRolesAsync(empId);
        }

        public async Task<EmployeeRole> AddRoleAsync(int roleId,EmployeeRole employeeRole)
        {
            employeeRole.RoleId = roleId;

            if (employeeRole.Employee != null && employeeRole.StartDate < employeeRole.Employee.BirthDate)
            {
                return null;
            }

            return await _employeeRepository.AddRoleAsync(employeeRole);
        }

        public async Task<Employee> UpdateAsync(Employee emp)
        {
            return await _employeeRepository.UpdateAsync(emp);
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            await _employeeRepository.DeleteRoleAsync(roleId);
        }
    }
}

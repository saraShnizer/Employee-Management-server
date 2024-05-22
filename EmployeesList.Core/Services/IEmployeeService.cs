﻿using EmployeesList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int empId);
        Task<IEnumerable<EmployeeRole>> GetRolesAsync(int empId);
        Task<Employee> AddAsync(Employee emp);
        Task<EmployeeRole> AddRoleAsync(int roleId,EmployeeRole employeeRole);
        Task<Employee> UpdateAsync(Employee emp);
        Task DeleteAsync(int empID);
        Task DeleteRoleAsync(int roleId);

    }
}

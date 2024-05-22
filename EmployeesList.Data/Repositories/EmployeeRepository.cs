using EmployeesList.Core.Entities;
using EmployeesList.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList.Data.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        //public async Task<DateTime> GetEarliestRoleStartDate(int empId)
        //{
        //    //Receiving the list of employee positions and sorting by start date
        //    var roles = await GetRolesAsync(empId);
        //    var earliestStartDate = roles.OrderBy(r => r.StartDate).FirstOrDefault().StartDate;

        //    return earliestStartDate;
        //}




        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dataContext.Employees
            .Where(e => e.Status == true)
            .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int empId)
        {
            return await _dataContext.Employees.FirstAsync(e => e.Id == empId);
        }

        public async Task<IEnumerable<EmployeeRole>> GetRolesAsync(int empId)
        {
            return await _dataContext.EmployeeRoles.Where(r => r.EmployeeId == empId)
            .ToListAsync();
        }

        public async Task<Employee> AddAsync(Employee emp)
        {
            emp.Status=true;
            //emp.StartDate = await GetEarliestRoleStartDate(emp.Id);
            _dataContext.Employees.Add(emp);

            await _dataContext.SaveChangesAsync();
            return emp;
        }

        public async Task<EmployeeRole> AddRoleAsync(EmployeeRole employeeRole)
        {
            _dataContext.EmployeeRoles.Add(employeeRole);
            await _dataContext.SaveChangesAsync();
            return employeeRole;
        }

        public async Task<Employee> UpdateAsync(Employee emp)
        {
            var existEmp = await GetByIdAsync(emp.Id);
            _dataContext.Entry(existEmp).CurrentValues.SetValues(emp);
            await _dataContext.SaveChangesAsync();
            return existEmp;
        }
        public async Task DeleteAsync(int empID)
        {
            var emp = await GetByIdAsync(empID);    
            emp.Status = false;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var empRole = await _dataContext.EmployeeRoles.FirstOrDefaultAsync(r => r.RoleId == roleId);
            _dataContext.EmployeeRoles.Remove(empRole);
            await _dataContext.SaveChangesAsync();

        }



       

    
    }

}

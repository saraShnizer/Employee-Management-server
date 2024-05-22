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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _dataContext;
        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Role> AddAsync(Role role)
        {
            _dataContext.Roles.Add(role);
            await _dataContext.SaveChangesAsync();
            return role;
        }

        public async Task DeleteAsync(int roleID)
        {
            var customer = await GetByIdAsync(roleID);
            _dataContext.Roles.Remove(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dataContext.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int roleID)
        {
            return await _dataContext.Roles.FirstAsync(r => r.Id == roleID);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var existRole = await GetByIdAsync(role.Id);
            _dataContext.Entry(existRole).CurrentValues.SetValues(role);
            await _dataContext.SaveChangesAsync();
            return existRole;
        }
    }
}

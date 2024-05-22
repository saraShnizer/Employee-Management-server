using EmployeesList.Core.Entities;
using EmployeesList.Core.Repositories;
using EmployeesList.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> AddAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        public async Task DeleteAsync(int roleID)
        {
            await _roleRepository.DeleteAsync(roleID);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
           return await _roleRepository.GetAllAsync();
        }

        public async Task<Role> GetByIdAsync(int roleID)
        {
          return await _roleRepository.GetByIdAsync(roleID);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
           return await _roleRepository.UpdateAsync(role);
        }
    }
}

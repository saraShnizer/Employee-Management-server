using EmployeesList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList.Core.DTOs
{
    public class EmployeeRoleDto
    {
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdmin { get; set; }

    }
}

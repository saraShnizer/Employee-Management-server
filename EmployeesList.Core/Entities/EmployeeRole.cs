using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList.Core.Entities
{
    public class EmployeeRole
    {
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}


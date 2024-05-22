using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EGender { male, female }
namespace EmployeesList.Core.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public EGender Gender { get; set; }
        public bool Status { get; set; }

    }

}

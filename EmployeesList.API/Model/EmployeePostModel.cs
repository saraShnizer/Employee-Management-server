using EmployeesList.Core.Entities;

namespace EmployeesList.API.Model
{
    public class EmployeePostModel
    {
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public EGender Gender { get; set; }

    }
}

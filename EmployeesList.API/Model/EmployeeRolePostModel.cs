namespace EmployeesList.API.Model
{
    public class EmployeeRolePostModel
    {
        //public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}

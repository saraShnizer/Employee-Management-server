using AutoMapper;
using EmployeesList.API.Model;
using EmployeesList.Core.Entities;



namespace EmployeesList.API.Mapping
{
    public class PostModelsMappingProfile:Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<RolePostModel, Role>();
            CreateMap<EmployeeRolePostModel, EmployeeRole>();
           
        }
    }
}

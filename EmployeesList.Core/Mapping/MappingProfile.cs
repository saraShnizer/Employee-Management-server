
using AutoMapper;
using EmployeesList.Core.DTOs;
using EmployeesList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeesList.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<EmployeeRole, EmployeeRoleDto>().ReverseMap();    


        }

    }
}

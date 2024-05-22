
using AutoMapper;
using EmployeesList.API.Model;
using EmployeesList.Core.DTOs;
using EmployeesList.Core.Entities;
using EmployeesList.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }
       

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel model)
        {
            var newEmployee = await _employeeService.AddAsync(_mapper.Map<Employee>(model));
            return Ok(_mapper.Map<EmployeeDto>(newEmployee));
        }
     
    

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel model)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            _mapper.Map(model, employee);
            await _employeeService.UpdateAsync(employee);
            employee = await _employeeService.GetByIdAsync(id);
            return Ok(_mapper.Map<Employee>(employee));

        }

       
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            await _employeeService.DeleteAsync(id);
            return Ok(_mapper.Map<Employee>(employee));

        }

        //role


        // GET api/<EmployeeController>/5/roles
        [HttpGet("{empId}/roles")]
        public async Task<ActionResult> GetRole(int empId)
        {
            var employeeRoles = await _employeeService.GetRolesAsync(empId);
            return Ok(_mapper.Map<IEnumerable<EmployeeRoleDto>>(employeeRoles));
        }

        // POST api/<EmployeeController>/role
        [HttpPost("{id}/roles")]
        public async Task<ActionResult> PostRole(int id,[FromBody] EmployeeRolePostModel model)
        {

            var newEmpRole = await _employeeService.AddRoleAsync(id,_mapper.Map<EmployeeRole>(model));
            return Ok(_mapper.Map<EmployeeRoleDto>(newEmpRole));
        }


        //// PUT api/<EmployeeController>/5/role
        //[HttpPut("{id}/role")]
        //public async Task<ActionResult> PutRole(int id, [FromBody] EmployeeRolePostModel model)
        //{
        //    var employee = await _employeeService.GetByIdAsync(id);
        //    if (employee is null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(model, employee);
        //    await _employeeService.UpdateAsync(employee);
        //    employee = await _employeeService.GetByIdAsync(id);
        //    return Ok(_mapper.Map<Employee>(employee));

        //}

        // DELETE api/<EmployeeController>/5/role
        [HttpDelete("{id}/roles")]
        public async Task<ActionResult> DeleteRoleAsync(int id)
        {
            var empRole = await _employeeService.GetRolesAsync(id);
            if (empRole is null)
            {
                return NotFound();
            }
            await _employeeService.DeleteRoleAsync(id);
            return Ok(_mapper.Map<EmployeeRole>(empRole));

        }
   

    }
}

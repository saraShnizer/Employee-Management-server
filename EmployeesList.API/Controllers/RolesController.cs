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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _RoleService;
        private readonly IMapper _mapper;
        public RolesController(IRoleService RoleService, IMapper mapper)
        {
            _RoleService = RoleService;
            _mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Roles = await _RoleService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(Roles));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var role = await _RoleService.GetByIdAsync(id);
            return Ok(_mapper.Map<RoleDto>(role));
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePostModel model)
        {
            //check if parentId exists
            var newRole = await _RoleService.AddAsync(_mapper.Map<Role>(model));
            return Ok(_mapper.Map<RoleDto>(newRole));
        }

        // PUT api/<RoleController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _RoleService.GetByIdAsync(id);
            if (role is null)
            {
                return NotFound();
            }
            await _RoleService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using AutoMapper;
using HighSchool.Core.Dtos;
using HighSchool.Core.Models;
using HighSchool.API.Models;
using HighSchool.Core.Services;
using HighSchool.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        // GET: api/<RolesController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _roleService.GetRoles();
            var list1 = list.Select(l => _mapper.Map<RoleDto>(l));
            return Ok(list1);
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePostModel role)
        {
            var roleToAdd = _mapper.Map<Role>(role);
            var addedUser =await _roleService.PostAsync(roleToAdd);
            var newRole = _roleService.GetById(addedUser.Id);
            var roleDto = _mapper.Map<RoleDto>(newRole);
            return Ok(roleDto);
        }
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var employee = _roleService.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            _roleService.Delete(id);
            return NoContent();
        }
    }
}

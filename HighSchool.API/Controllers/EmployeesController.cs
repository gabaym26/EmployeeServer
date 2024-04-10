using AutoMapper;
using HighSchool.API.Models;
using HighSchool.Core.Dtos;
using HighSchool.Core.Models;
using HighSchool.Core.Services;
using HighSchool.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers
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

        // GET: api/<employeesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list =await _employeeService.GetemployeesAsync();
            var list1= list.Select(l => _mapper.Map<EmployeeDto>(l));
            return Ok(list1);
        } 

        // GET api/<employeesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var employee =  _mapper.Map<EmployeeDto>(_employeeService.GetById(id));
            return Ok(employee);
        }
                // POST api/<employeesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel employee)
        {
            var employeeToAdd = _mapper.Map<Employee>(employee);
            var addedEmployee =await _employeeService.PostAsync(employeeToAdd);
            var newEmployee =_employeeService.GetById(addedEmployee.Id);
            var employeeDto = _mapper.Map<EmployeeDto>(newEmployee);
            return Ok(employeeDto);
        }

        // PUT api/<employeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var existUser =_employeeService.GetById(id);
            if (existUser is null)
            {
                return NotFound();
            }
            var employeeToUpdate=_mapper.Map<Employee>(employee);
            return Ok(_mapper.Map< EmployeeDto >(await _employeeService.PutAsync(id,employeeToUpdate)));
        }

        // DELETE api/<employeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee =_employeeService.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            _employeeService.Delete(id);
            return NoContent();
        }
    }
}

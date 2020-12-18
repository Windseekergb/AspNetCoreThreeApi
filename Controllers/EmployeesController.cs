using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("V1/[Controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRespository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRespository = employeeRepository;
        }
        [HttpGet(template:"{departmentId}")]
        public async Task<IActionResult> GetByDepartmentId(int departmentID)
        {
            var employee = await _employeeRespository.GetByDepartmentId(departmentID);
            if (!employee.Any())
            {
                return NoContent();
            }
            return Ok(employee);
        }
        [HttpGet(template:"One/{Id}", Name ="GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _employeeRespository.GetById(Id);
       
            return Ok(result);

        }

        [HttpPost]
        public  async Task<IActionResult> Add([FromBody] Employee  em)
        {
            var added = await _employeeRespository.Add(em);
            return CreatedAtRoute(routeName: "GetById", routeValues: new { id = added.Id }, value: added);
        }
         
        [HttpPut(template:"{id}")]

        public  async  Task<IActionResult> Fire(int Id)
        {
            var result = await _employeeRespository.Fire(Id);
            return Ok(result);
        }
    }
}

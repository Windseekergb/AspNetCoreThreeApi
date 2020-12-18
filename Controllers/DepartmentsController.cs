using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeApi.Models;
using ThreeApi.Repositories;
using System.Linq;

namespace ThreeApi.Controllers
{
    [Route("V1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentrepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentrepository = departmentRepository;
        }

        [HttpGet]//V1/Department  Verb:get;

        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var department = await _departmentrepository.GetAll();
            if (!department.Any())
            {
                return NoContent();
            }
            return Ok(department);
        }

        [HttpPost]//V1/Department  Verb:post;
        public async Task<ActionResult<Department>> Add([FromBody] Department department)
        {
            var added = await _departmentrepository.Add(department);
            return Ok(added);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using ZooManager.Api.Models;
using ZooManager.Api.Models.Requests;
using ZooManager.Api.Services;

namespace ZooManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("create", Name = "EmployeeCreate")]
        public ActionResult<int> Create([FromBody] CreateEmployeeRequest request)
        {
            var employee = new Employee()
            {
                Name = request.Name,
                Position = request.Position,
                ContactInfo = request.ContactInfo
            };
            return Ok(_employeeRepository.Add(employee));
        }

        [HttpPut("update", Name = "EmployeeUpdate")]
        public ActionResult<bool> Update([FromBody] UpdateEmployeeRequest request)
        {
            var employee = new Employee()
            {
                Id = request.Id,
                Name = request.Name,
                Position = request.Position,
                ContactInfo = request.ContactInfo
            };
            return Ok(_employeeRepository.Update(employee));
        }

        [HttpDelete("delete", Name = "EmployeeDelete")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_employeeRepository.Remove(id));
        }

        [HttpGet("get-all", Name = "EmployeeGetAll")]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("get-by-id", Name = "EmployeeGetById")]
        public ActionResult<Employee?> GetById(int id)
        {
            return Ok(_employeeRepository.GetById(id));
        }

    }
}

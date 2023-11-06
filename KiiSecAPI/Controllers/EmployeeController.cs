using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;
using KiiSecAPI.Interfaces;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeePermissionsRepository _employeePermissionsRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeePermissionsRepository employeePermissionsRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeePermissionsRepository = employeePermissionsRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmployee() 
        {
            var employee = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employee);
        }

        [HttpGet("{ID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployeeByID(int ID)
        {
            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployeeById(ID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employee);
        }

        [HttpGet("Organization/{organizationId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployeeByOrganizationID(int organizationId)
        {
            var employee = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployeesByOrganization(organizationId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployee([FromQuery] int permissionId, [FromBody] EmployeeDto employeeCreate)
        {
            if (employeeCreate == null)
            {
                return BadRequest(ModelState);
            }

            var employee = _employeeRepository.GetEmployees()
                .Where(e => e.Login.Trim().ToUpper() == employeeCreate.Login.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (employee != null)
            {
                ModelState.AddModelError("", "Employee already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employee>(employeeCreate);

            if (!_employeeRepository.CreateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500,ModelState);
            }

            return Ok("Succesfully created");
        }


        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateEmployee([FromBody] EmployeeDto updatedEmployee)
        {
            int employeeId = updatedEmployee.ID;
            if (updatedEmployee == null)
            {
                return BadRequest(ModelState);
            }

            if (employeeId != updatedEmployee.ID)
            {
                return BadRequest(ModelState);
            }

            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
          

            var employeeMap = _mapper.Map<Employee>(updatedEmployee);

            if (!_employeeRepository.UpdateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employeePermissionsToDelete = _employeePermissionsRepository.GetPermissonsOfEmployee(employeeId);
            var employeeToDelete = _employeeRepository.GetEmployeeById(employeeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_employeePermissionsRepository.DeleteEmployeePermissions(employeePermissionsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_employeeRepository.DeleteEmployee(employeeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting employee");
            }

            return NoContent();
        }

        
    }
}
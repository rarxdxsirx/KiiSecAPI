using AutoMapper;
using KiiSecAPI.Dto;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiiSecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePermissionController : Controller
    {
        private readonly IEmployeePermissionsRepository _employeePermissionsRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;

        public EmployeePermissionController(IEmployeePermissionsRepository employeePermissionsRepository, 
            IMapper mapper, IEmployeeRepository employeeRepository, IPermissionsRepository permissionsRepository)
        {
            _employeePermissionsRepository = employeePermissionsRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _permissionsRepository = permissionsRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeePermissions>))]
        public IActionResult GetEmployeePermissions()
        {
            var employeePermissions = _mapper.Map<List<EmployeePermissionsDto>>(_employeePermissionsRepository.GetEmployeePermissions());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employeePermissions);
        }

        [HttpGet("employee/{employeeId}")]
        [ProducesResponseType(200, Type = typeof(EmployeePermissions))]
        [ProducesResponseType(400)]
        public IActionResult GetPermissonsOfEmployee(int employeeId)
        {
            var reviews = _mapper.Map<List<EmployeePermissionsDto>>(_employeePermissionsRepository.GetPermissonsOfEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployeePermission([FromQuery] int employeeId,[FromQuery] int permissionId)
        {

            var employeePermission = _employeePermissionsRepository.GetEmployeePermissions()
                .Where(e => e.EmployeeID == employeeId)
                .Where(e => e.PermissionID == permissionId)
                .FirstOrDefault();

            if (employeePermission != null)
            {
                ModelState.AddModelError("", "Employee permission already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeePermissionMap = _mapper.Map<EmployeePermissions>(new EmployeePermissions() { EmployeeID = employeeId, PermissionID = permissionId});

            employeePermissionMap.Permission = _permissionsRepository.GetPermissionById(permissionId);
            employeePermissionMap.Employee = _employeeRepository.GetEmployeeById(employeeId);

            if (!_employeePermissionsRepository.CreateEmployeePermission(employeePermissionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}

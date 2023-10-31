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

        public EmployeePermissionController(IEmployeePermissionsRepository employeePermissionsRepository)
        {
            _employeePermissionsRepository = employeePermissionsRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeePermissions>))]
        public IActionResult GetEmployeePermissions()
        {
            var employeePermissions = _employeePermissionsRepository.GetEmployeePermissions();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employeePermissions);
        }
    }
}

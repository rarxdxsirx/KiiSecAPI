using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitStatus>))]
        public IActionResult GetVisitsStatus()
        {
            var permissions = _employeePermissionsRepository.GetEmployeePermissions();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(permissions);
        }
    }
}

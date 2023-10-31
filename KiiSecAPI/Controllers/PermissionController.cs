using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiiSecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IPermissionsRepository _permissionsRepository;

        public PermissionController(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Permission>))]
        public IActionResult GetVisitsStatus()
        {
            var permissions = _permissionsRepository.GetPermissions();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(permissions);
        }
    }
}

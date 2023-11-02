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
    public class PermissionController : Controller
    {
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionsRepository permissionsRepository, IMapper mapper)
        {
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Permission>))]
        public IActionResult GetPermissions()
        {
            var permissions = _mapper.Map<List<PermissionDto>>(_permissionsRepository.GetPermissions());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(permissions);
        }


    }
}

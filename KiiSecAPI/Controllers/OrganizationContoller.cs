using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;
using System.Collections.Generic;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationController(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organization>))]
        public IActionResult GetOrganization() 
        {
            var organization = _mapper.Map<List<OrganizationDto>>(_organizationRepository.GetOrganization());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(organization);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organization>))]
        public IActionResult GetOrganization(int id)
        {
            if (!_organizationRepository.OrganizationExists(id))
            {
                return NotFound();
            }

            var organization = _mapper.Map<OrganizationDto>(_organizationRepository.GetOrganization(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(organization);
        }
    }
}
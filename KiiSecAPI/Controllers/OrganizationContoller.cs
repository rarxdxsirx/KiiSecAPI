using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;
using System.Collections.Generic;
using KiiSecAPI.Data;

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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployee([FromBody] OrganizationDto organizationCreate)
        {
            if (organizationCreate == null)
            {
                return BadRequest(ModelState);
            }

            var organization = _organizationRepository.GetOrganization()
                .Where(e => e.Login.Trim().ToUpper() == organizationCreate.Login.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (organization != null)
            {
                ModelState.AddModelError("", "Organization already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var organizationMap = _mapper.Map<Organization>(organizationCreate);

            if (!_organizationRepository.CreateOrganization(organizationMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }
    }
}
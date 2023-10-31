using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using KiiSecAPI.Data;
using AutoMapper;
using KiiSecAPI.Dto;
using System.Collections.Generic;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : Controller
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitController(IVisitRepository visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visit>))]
        public IActionResult GetVisits() 
        {
            var visit = _mapper.Map<List<VisitDto>>(_visitRepository.GetVisits());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visit);
        }

        [HttpGet("{groupID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visit>))]
        [ProducesResponseType(400)]
        public IActionResult GetVisitsByGroup(int groupID)
        {

            var visit = _mapper.Map<List<VisitDto>>(_visitRepository.GetVisitsByGroup(groupID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visit);
        }
    }
}
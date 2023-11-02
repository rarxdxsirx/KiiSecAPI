using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorGroupController : Controller
    {
        private readonly IVisitorGroupRepository _visitorGroupRepository;
        private readonly IMapper _mapper;

        public VisitorGroupController(IVisitorGroupRepository visitorGroupRepository, IMapper mapper)
        {
            _visitorGroupRepository = visitorGroupRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitorsGroup>))]
        public IActionResult GetVisitsStatus() 
        {
            var visitorsGroup = _mapper.Map<List<VisitorsGroupDto>>(_visitorGroupRepository.GetVisitorsGroups());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitorsGroup);
        }
    }
}
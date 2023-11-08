using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Repository;
using KiiSecAPI.Data;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitOfVisitorController : Controller
    {
        private readonly IVisitOfVisitorRepository _visitsOfVisitorsRepository;
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitOfVisitorController(IVisitOfVisitorRepository visitsOfVisitorsRepository,
            IVisitorRepository visitorRepository, IVisitRepository visitRepository, IMapper mapper)
        {
            _visitsOfVisitorsRepository = visitsOfVisitorsRepository;
            _visitorRepository = visitorRepository;
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitOfVisitor>))]
        public IActionResult GetVisitsOfVisitors()
        {
            var visitsOfVisitors = _mapper.Map<List<VisitOfVisitorDto>>(_visitsOfVisitorsRepository.GetVisitsOfVisitors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitsOfVisitors);
        }

        [HttpGet("visitor/{visitorId}")]
        [ProducesResponseType(200, Type = typeof(VisitOfVisitor))]
        [ProducesResponseType(400)]
        public IActionResult GetPermissonsOfEmployee(int visitorId)
        {
            var permissionsOfEmployee = _mapper.Map<List<VisitOfVisitorDto>>(_visitsOfVisitorsRepository.GetVisitsOfVisitor(visitorId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(permissionsOfEmployee);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateVisitOfVisitor([FromQuery] int visitorId, [FromQuery] int visitId)
        {
            var visitOfVisitor = _visitsOfVisitorsRepository.GetVisitsOfVisitors()
                .Where(e => e.VisitorId == visitorId)
                .Where(e => e.VisitId == visitId)
                .FirstOrDefault();

            if (visitOfVisitor != null)
            {
                ModelState.AddModelError("", "Employee permission already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var visitOfVisitorMap = _mapper.Map<VisitOfVisitor>(new VisitOfVisitor() { VisitorId = visitorId, VisitId = visitId });

            visitOfVisitorMap.Visit = _visitRepository.GetVisitById(visitId);
            visitOfVisitorMap.Visitor = _visitorRepository.GetVisitorByID(visitorId);

            if (!_visitsOfVisitorsRepository.CreateVisitOfVisitor(visitOfVisitorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteEmployee([FromQuery] int visitorId, [FromQuery] int visitId)
        {
            var visitOfVisitor = _visitsOfVisitorsRepository.GetVisitsOfVisitors()
                .Where(e => e.VisitorId == visitorId)
                .Where(e => e.VisitId == visitId)
                .FirstOrDefault();

            if (visitOfVisitor == null)
            {
                ModelState.AddModelError("", "Employee permission doesnt exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _visitsOfVisitorsRepository.DeleteVisitOfVisitor(visitOfVisitor);

            return NoContent();
        }
    }
}
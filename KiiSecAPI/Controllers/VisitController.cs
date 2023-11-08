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
        private readonly IVisitorRepository _visitorRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IVisitOfVisitorRepository _visitOfVisitorRepository;
        private readonly IMapper _mapper;

        public VisitController(IVisitRepository visitRepository, IMapper mapper, IVisitOfVisitorRepository visitOfVisitorRepository, IVisitorRepository visitorRepository)
        {
            _visitRepository = visitRepository;
            _visitorRepository = visitorRepository;
            _visitOfVisitorRepository = visitOfVisitorRepository;
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

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visit>))]
        [ProducesResponseType(400)]
        public IActionResult GetVisitsByID(int id)
        {

            var visit = _mapper.Map<VisitDto>(_visitRepository.GetVisitById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visit);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateVisit([FromBody] VisitDto visitCreate)
        {
            if (visitCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var visitMap = _mapper.Map<Visit>(visitCreate);

            if (!_visitRepository.CreateVisit(visitMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }

        [HttpPut("{visitId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateVisit(int visitId, [FromBody] VisitDto updatedVisit)
        {
            if (updatedVisit == null)
            {
                return BadRequest(ModelState);
            }

            if (visitId != updatedVisit.ID)
            {
                return BadRequest(ModelState);
            }

            if (!_visitRepository.VisitExists(visitId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var visitMap = _mapper.Map<Visit>(updatedVisit);

            if (!_visitRepository.UpdateVisit(visitMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{visitId}/visitStatus")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult SetVisitStatus(int visitId, [FromQuery] int visitStatus)
        {

            if (!_visitRepository.VisitExists(visitId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var visitMap = _visitRepository.GetVisitById(visitId);

            visitMap.VisitStatusID = visitStatus;

            if (!_visitRepository.UpdateVisit(visitMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{visitId}/arrivalTime")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult SetVisitArrivalStatus(int visitId, [FromQuery] DateTime arrivalDateTime)
        {
            if (!_visitRepository.VisitExists(visitId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var visitMap = _visitRepository.GetVisitById(visitId);

            visitMap.ArrivalDateTime = arrivalDateTime;

            if (!_visitRepository.UpdateVisit(visitMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{visitId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteVisit(int visitId)
        {
            if (!_visitRepository.VisitExists(visitId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var visitToDelete = _visitRepository.GetVisitById(visitId);

            //VisitOfVisitor visitOfVisitor = new VisitOfVisitor()
            //{
            //    Visit = visitToDelete,
            //    VisitId = visitId,
            //    Visitor = _visitorRepository.

            //};

            //var visitOfVisitorToDelete = _visitOfVisitorRepository.DeleteVisitOfVisitor(visitOfVisitor);
            

            if (!_visitRepository.DeleteVisit(visitToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting visit");
            }

            return NoContent();
        }
    }
}
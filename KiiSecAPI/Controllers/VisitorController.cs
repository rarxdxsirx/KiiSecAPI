using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorController(IVisitorRepository visitorRepository, IMapper mapper)
        {
            _visitorRepository = visitorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visitor>))]
        public IActionResult GetVisits() 
        {
            var visitor = _mapper.Map<List<Visitor>>(_visitorRepository.GetVisitors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visitor>))]
        [ProducesResponseType(400)]
        public IActionResult GetVisitorByID(int id)
        {
            var visitor = _mapper.Map<Visitor>(_visitorRepository.GetVisitorByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateVisitor([FromBody] VisitorDto visitorCreate)
        {
            if (visitorCreate == null) { return BadRequest(ModelState); }

            var visitor = _visitorRepository.GetVisitors()
                .Where(v => v.Login.Trim().ToUpper() == visitorCreate.Login.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (visitor != null)
            {
                ModelState.AddModelError("", "Visitor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var visitorMap = _mapper.Map<Visitor>(visitorCreate);

            if (!_visitorRepository.CreateVisitor(visitorMap))
            {
                ModelState.AddModelError("", "Something weng wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }
    }
}
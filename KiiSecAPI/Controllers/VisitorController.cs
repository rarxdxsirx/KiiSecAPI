using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorController(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visitor>))]
        public IActionResult GetVisits() 
        {
            var visitor = _visitorRepository.GetVisitors();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitor);
        }
    }
}
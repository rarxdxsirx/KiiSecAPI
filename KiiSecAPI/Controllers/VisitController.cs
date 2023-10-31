using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : Controller
    {
        private readonly IVisitRepository _visitRepository;

        public VisitController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visit>))]
        public IActionResult GetVisits() 
        {
            var visit = _visitRepository.GetVisits();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visit);
        }
    }
}
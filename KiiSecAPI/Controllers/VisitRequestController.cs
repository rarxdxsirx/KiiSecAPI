using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitRequestController : Controller
    {
        private readonly IVisitRequestRepository _visitRequestRepository;

        public VisitRequestController(IVisitRequestRepository visitRequestRepository)
        {
            _visitRequestRepository = visitRequestRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitRequest>))]
        public IActionResult GetVisits() 
        {
            var visitRequest = _visitRequestRepository.GetVisitRequests();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitRequest);
        }
    }
}
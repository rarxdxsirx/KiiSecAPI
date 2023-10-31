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
        public IActionResult GetVisitRequests() 
        {
            var visitRequest = _visitRequestRepository.GetVisitRequests();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitRequest);
        }

        [HttpGet("{groupID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitRequest>))]
        [ProducesResponseType(400)]
        public IActionResult GetVisitRequestsByGroup(int groupID)
        {

            var visitRequest = _visitRequestRepository.GetVisitRequestsByGroup(groupID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitRequest);
        }
    }
}
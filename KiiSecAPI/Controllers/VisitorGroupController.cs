using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorGroupController : Controller
    {
        private readonly IVisitorGroupRepository _visitorGroupRepository;

        public VisitorGroupController(IVisitorGroupRepository visitorGroupRepository)
        {
            _visitorGroupRepository = visitorGroupRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitorsGroup>))]
        public IActionResult GetVisitsStatus() 
        {
            var visitorsGroup = _visitorGroupRepository.GetVisitorsGroups();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitorsGroup);
        }
    }
}
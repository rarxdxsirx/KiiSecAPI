using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitStatusController : Controller
    {
        private readonly IVisitStatusRepository _visitStatusRepository;

        public VisitStatusController(IVisitStatusRepository visitStatusRepository)
        {
            _visitStatusRepository = visitStatusRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitStatus>))]
        public IActionResult GetVisitsStatus() 
        {
            var visitsstatus = _visitStatusRepository.GetVisitsStatus();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(visitsstatus);
        }
    }
}
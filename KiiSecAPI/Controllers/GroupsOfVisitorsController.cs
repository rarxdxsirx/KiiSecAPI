using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsOfVisitorsController : Controller
    {
        private readonly IGroupsOfVisitorsRepository _groupsOfVisitorsRepository;

        public GroupsOfVisitorsController(IGroupsOfVisitorsRepository groupsOfVisitorsRepository)
        {
            _groupsOfVisitorsRepository = groupsOfVisitorsRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupsOfVisitors>))]
        public IActionResult GetVisitsStatus() 
        {
            var groupofVisitors = _groupsOfVisitorsRepository.GetGroupsOfVisitors();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(groupofVisitors);
        }
    }
}
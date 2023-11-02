using KiiSecAPI.Intefaces;
using Microsoft.AspNetCore.Mvc;
using KiiSecAPI.Models;
using AutoMapper;
using KiiSecAPI.Dto;

namespace KiiSecAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsOfVisitorsController : Controller
    {
        private readonly IGroupsOfVisitorsRepository _groupsOfVisitorsRepository;
        private readonly IMapper _mapper;

        public GroupsOfVisitorsController(IGroupsOfVisitorsRepository groupsOfVisitorsRepository, IMapper mapper)
        {
            _groupsOfVisitorsRepository = groupsOfVisitorsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupsOfVisitors>))]
        public IActionResult GetVisitsStatus() 
        {
            var groupofVisitors = _mapper.Map<List<GroupsOfVisitorsDto>>(_groupsOfVisitorsRepository.GetGroupsOfVisitors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(groupofVisitors);
        }
    }
}
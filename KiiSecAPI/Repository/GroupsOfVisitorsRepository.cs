using KiiSecAPI.Data;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Repository
{
    public class GroupsOfVisitorsRepository : IGroupsOfVisitorsRepository
    {
        private readonly DataContext _context;
        public GroupsOfVisitorsRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<GroupsOfVisitors> GetGroupsOfVisitors()
        {
            return _context.GroupsOfVisitors.OrderBy(p => p.VisitorId).ToList();
        }
    }
}

using KiiSecAPI.Data;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Repository
{
    public class VisitorGroupRepository : IVisitorGroupRepository
    {
        private readonly DataContext _context;
        public VisitorGroupRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateVisitorGroup(VisitorsGroup visitorsGroup)
        {
            var groupEntity = _context.Visitors.

            var gOV = new GroupsOfVisitors()
            {
                VisitorsGroup = visitorsGroup,
                Visitor = visitor
            };

            _context.Add(gOV);
            _context.Add(visitorsGroup);

            return Save();
        }

        public ICollection<VisitorsGroup> GetVisitorsGroups()
        {
            return _context.VisitorsGroups.OrderBy(p => p.ID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

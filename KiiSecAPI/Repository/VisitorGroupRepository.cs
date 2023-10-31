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

        public ICollection<VisitorsGroup> GetVisitorsGroups()
        {
            return _context.VisitorsGroups.OrderBy(p => p.ID).ToList();
        }
    }
}

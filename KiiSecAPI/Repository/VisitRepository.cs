using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Data
{
    public class VisitRepository : IVisitRepository
    {
        private readonly DataContext _context;
        public VisitRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Visit> GetVisits()
        {
            return _context.Visits.OrderBy(p => p.ID).ToList();
        }

        public ICollection<Visit> GetVisitsByGroup(int groupID)
        {
            return _context.Visits.OrderBy(p => p.ID).Where(p => p.VisitorsGroupID == groupID).ToList();
        }

        public bool VisitExists(int id)
        {
            return _context.Visits.Any(p => p.ID == id);
        }
    }
}


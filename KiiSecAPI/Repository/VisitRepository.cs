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
    }
}


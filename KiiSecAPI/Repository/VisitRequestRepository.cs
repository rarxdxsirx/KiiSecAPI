using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Data
{
    public class VisitRequestRepository : IVisitRequestRepository
    {
        private readonly DataContext _context;
        public VisitRequestRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<VisitRequest> GetVisitRequests()
        {
            return _context.VisitRequests.OrderBy(p => p.ID).ToList();
        }
    }
}


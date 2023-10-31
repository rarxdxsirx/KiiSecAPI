using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Data
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly DataContext _context;
        public VisitorRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Visitor> GetVisitors()
        {
            return _context.Visitors.OrderBy(p => p.ID).ToList();
        }
    }
}


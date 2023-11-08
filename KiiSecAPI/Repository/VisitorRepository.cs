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

        public Visitor GetVisitorByID(int id)
        {
            return _context.Visitors.FirstOrDefault(p => p.ID == id);
        }

        public bool CreateVisitor(Visitor visitor)
        {
            _context.Add(visitor);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVisitor(Visitor visitor)
        {
            _context.Update(visitor);
            return Save();
        }

        public bool VisitorExists(int id)
        {
            return _context.Visitors.Any(a => a.ID == id);
        }
    }
}


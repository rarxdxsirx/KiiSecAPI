using KiiSecAPI.Data;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Repository
{
    public class VisitsOfVisitorsRepository : IVisitOfVisitorRepository
    {
        private readonly DataContext _context;
        public VisitsOfVisitorsRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateVisitOfVisitor(VisitOfVisitor visitsOfVisitors)
        {
            _context.Add(visitsOfVisitors);
            return Save();
        }

        public bool DeleteVisitOfVisitor(VisitOfVisitor visitsOfVisitors)
        {
            _context.Remove(visitsOfVisitors);
            return Save();
        }

        public bool DeleteVisitsOfVisitors(List<VisitOfVisitor> visitsOfVisitors)
        {
            _context.RemoveRange(visitsOfVisitors);
            return Save();
        }

        public ICollection<VisitOfVisitor> GetVisitsOfVisitor(int visitorID)
        {
            return _context.VisitsOfVisitors.Where(v => v.VisitorId == visitorID).ToList();
        }

        public ICollection<VisitOfVisitor> GetVisitsOfVisitors()
        {
            return _context.VisitsOfVisitors.OrderBy(p => p.VisitorId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;
using Org.BouncyCastle.Asn1.Cms.Ecc;

namespace KiiSecAPI.Data
{
    public class VisitRepository : IVisitRepository
    {
        private readonly DataContext _context;
        public VisitRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateVisit(Visit visit)
        {
            _context.Add(visit);
            return Save();
        }

        public bool DeleteVisit(Visit visit)
        {
            _context.Remove(visit);
            return Save();
        }

        public Visit GetVisitById(int id)
        {
            return _context.Visits.FirstOrDefault(v => v.ID == id);
        }

        public ICollection<Visit> GetVisits()
        {
            return _context.Visits.OrderBy(p => p.ID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVisit(Visit visit)
        {
            _context.Update(visit);
            return Save();
        }

        public bool VisitExists(int id)
        {
            return _context.Visits.Any(p => p.ID == id);
        }
    }
}


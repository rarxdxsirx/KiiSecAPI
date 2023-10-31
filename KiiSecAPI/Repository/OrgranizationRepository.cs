using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Data
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DataContext _context;
        public OrganizationRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Organization> GetOrganization()
        {
            return _context.Organizations.OrderBy(p => p.ID).ToList();
        }

        public Organization GetOrganization(int id)
        {
            return _context.Organizations.Where(p => p.ID == id).FirstOrDefault();
        }

        public bool OrganizationExists(int id) 
        { 
            return _context.Organizations.Any(p => p.ID == id);
        }
    }
}


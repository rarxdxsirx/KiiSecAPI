using KiiSecAPI.Dto;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiiSecAPI.Data
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DataContext _context;
        public OrganizationRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOrganization(Organization organization)
        {
            _context.Add(organization);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}


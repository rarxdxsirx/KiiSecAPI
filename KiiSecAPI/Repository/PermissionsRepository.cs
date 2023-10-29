using KiiSecAPI.Data;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Repository
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly DataContext _context;
        public PermissionsRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Permission> GetPermissions()
        {
            return _context.Permissions.OrderBy(p => p.ID).ToList();
        }
    }
}

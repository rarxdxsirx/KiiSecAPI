using KiiSecAPI.Data;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Repository
{
    public class EmployeePermissionsRepository : IEmployeePermissionsRepository
    {
        private readonly DataContext _context;
        public EmployeePermissionsRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<EmployeePermissions> GetEmployeePermissions()
        {
            return _context.EmployeePermissions.OrderBy(p => p.EmpNPerID).ToList();
        }
    }
}

using KiiSecAPI.Data;
using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KiiSecAPI.Repository
{
    public class EmployeePermissionsRepository : IEmployeePermissionsRepository
    {
        private readonly DataContext _context;
        public EmployeePermissionsRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEmployeePermission(EmployeePermissions employeePermission)
        {
            _context.Add(employeePermission);
            return Save();
        }

        public bool DeleteEmployeePermission(EmployeePermissions employeePermission)
        {
            _context.Remove(employeePermission);
            return Save();
        }

        public bool DeleteEmployeePermissions(List<EmployeePermissions> employeePermissions)
        {
            _context.RemoveRange(employeePermissions);
            return Save();
        }

        public ICollection<EmployeePermissions> GetEmployeePermissions()
        {
            return _context.EmployeePermissions.OrderBy(p => p.EmployeeID).ToList();
        }

        public ICollection<EmployeePermissions> GetPermissonsOfEmployee(int employeeID)
        {
            return _context.EmployeePermissions.Where(p => p.EmployeeID == employeeID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

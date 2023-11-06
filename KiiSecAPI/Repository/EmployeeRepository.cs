using KiiSecAPI.Intefaces;
using KiiSecAPI.Interfaces;
using KiiSecAPI.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KiiSecAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public bool DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
            return Save();
        }

        public bool EmployeeExists(int ID)
        {
            return _context.Employees.Any(e => e.ID == ID);
        }

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(p => p.ID).ToList();
        }
        public Employee GetEmployeeById(int ID) 
        {
            return _context.Employees.FirstOrDefault(p => p.ID == ID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Employee> GetEmployeesByOrganization(int organizationId)
        {
            return _context.Employees.Where(e => e.OrganizationId == organizationId).ToList();
        }

        public bool CreateEmployee(Employee employee)
        {          
            _context.Add(employee);

            return Save();
        }

        public bool UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            return Save();
        }

        public bool AddEmployeePermission(Employee employee, int permissionId) // 1
        {
            var permissionEntity = _context.Permissions.FirstOrDefault(p => p.ID == permissionId);

            var employeePermission = new EmployeePermissions()
            {
                Employee = employee,
                Permission = permissionEntity
            };

            _context.Add(employeePermission);
            return Save();
        }

        public bool RemoveEmployeePermission(Employee employee, int permissionId) // 2
        {
            var permissionEntity = _context.Permissions.FirstOrDefault(p => p.ID == permissionId);
            var employeePermission = new EmployeePermissions()
            {
                Employee = employee,
                Permission = permissionEntity
            };
            _context.Remove(employeePermission);
            return Save();
        }
    }
}


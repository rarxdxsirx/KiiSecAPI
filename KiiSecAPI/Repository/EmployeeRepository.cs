using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Employee> GetEmployee()
        {
            return _context.Employees.OrderBy(p => p.ID).ToList();
        }
    }
}


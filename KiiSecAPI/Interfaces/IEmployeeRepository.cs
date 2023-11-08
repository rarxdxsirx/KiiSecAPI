using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        ICollection<Employee> GetEmployeesByOrganization(int organizationId);
        Employee GetEmployeeById(int ID);
        bool EmployeeExists(int ID); 
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}



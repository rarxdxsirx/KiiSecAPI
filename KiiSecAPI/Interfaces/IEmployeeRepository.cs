using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        ICollection<Employee> GetEmployeesByOrganization(int organizationId);
        Employee GetEmployeeById(int ID);
        bool EmployeeExists(int ID); //TODO Exists 
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool AddEmployeePermission(Employee employee, int permissionId);
        bool RemoveEmployeePermission(Employee employee, int permissionId);
        bool DeleteEmployee(Employee employee);
        bool Save();

        //TODO Get employees by organization
    }
}



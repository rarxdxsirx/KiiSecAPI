using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployeeById(int ID);
        bool EmployeeExists(int ID); //TODO Exists 
        bool CreateEmployee(int permissionId, Employee employee);
        bool UpdateEmployee(int permissionId, Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();

        //TODO Get employees by organization
    }
}



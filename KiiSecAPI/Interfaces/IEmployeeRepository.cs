using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployee();
    }
}



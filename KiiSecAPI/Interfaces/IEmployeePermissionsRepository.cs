using KiiSecAPI.Models;

namespace KiiSecAPI.Interfaces
{
    public interface IEmployeePermissionsRepository
    {
        ICollection<EmployeePermissions> GetEmployeePermissions();

        ICollection<EmployeePermissions> GetPermissonsOfEmployee(int employeeID);
        bool CreateEmployeePermission(EmployeePermissions employeePermission);
        bool DeleteEmployeePermission(EmployeePermissions employeePermission); //TODO Add DeleteEmployeePermission to Controller
        bool DeleteEmployeePermissions(List<EmployeePermissions> employeePermissions);
        bool Save();

    }
}

using KiiSecAPI.Models;

namespace KiiSecAPI.Interfaces
{
    public interface IEmployeePermissionsRepository
    {
        ICollection<EmployeePermissions> GetEmployeePermissions();
    }
}

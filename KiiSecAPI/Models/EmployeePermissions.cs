using Microsoft.EntityFrameworkCore;

namespace KiiSecAPI.Models
{
    public class EmployeePermissions
    {
        public int EmployeeID { get; set; }
        public int PermissionID { get; set; }
        public Employee Employee { get; set; }
        public Permission Permission { get; set; }

    }
}

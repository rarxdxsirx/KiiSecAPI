using KiiSecAPI.Models;

namespace KiiSecAPI.Dto
{
    public class EmployeeDto : User
    {
        public int OrganizationId { get; set; }
        public string Department { get; set; }
    }
}

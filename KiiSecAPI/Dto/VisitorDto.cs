using KiiSecAPI.Models;

namespace KiiSecAPI.Dto
{
    public class VisitorDto : User
    {
        public string? VisitorOrganization { get; set; }
    }
}

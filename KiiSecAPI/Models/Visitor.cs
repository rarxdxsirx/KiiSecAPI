namespace KiiSecAPI.Models
{
    public class Visitor : User
    {
        public string? VisitorOrganization { get; set; }
        public string PassportData { get; set; }
        public ICollection<GroupsOfVisitors> GroupsOfVisitors { get; set;}
    }
}

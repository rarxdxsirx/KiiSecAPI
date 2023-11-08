namespace KiiSecAPI.Models
{
    public class Visitor : User
    {
        public string? VisitorOrganization { get; set; }
        public ICollection<VisitOfVisitor> VisitsOfVisitors { get; set;}
    }
}

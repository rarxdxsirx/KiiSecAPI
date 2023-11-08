using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitOfVisitorRepository
    {
        ICollection<VisitOfVisitor> GetVisitsOfVisitors();
        ICollection<VisitOfVisitor> GetVisitsOfVisitor(int visitorID);
        bool CreateVisitOfVisitor(VisitOfVisitor visitsOfVisitors);
        bool DeleteVisitOfVisitor(VisitOfVisitor visitsOfVisitors);
        bool DeleteVisitsOfVisitors(List<VisitOfVisitor> visitsOfVisitors);
        bool Save();
    }
}



using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitorGroupRepository
    {
        ICollection<VisitorsGroup> GetVisitorsGroups();
    }
}



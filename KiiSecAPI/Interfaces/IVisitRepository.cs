using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitRepository
    {
        ICollection<Visit> GetVisits();
        ICollection<Visit> GetVisitsByGroup(int groupID);
        bool VisitExists(int id);
    }
}



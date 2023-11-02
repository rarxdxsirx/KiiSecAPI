using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitStatusRepository
    {
        ICollection<VisitStatus> GetVisitsStatus();
        bool VisitStatusExists(int id);
    }
}



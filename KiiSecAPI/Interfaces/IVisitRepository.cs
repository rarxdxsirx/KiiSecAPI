using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitRepository
    {
        ICollection<Visit> GetVisits();
        Visit GetVisitById(int id);
        bool CreateVisit(Visit visit);
        bool UpdateVisit(Visit visit);
        bool DeleteVisit(Visit visit);
        //bool SetVisitStatus(Visit visit);
        //bool SetVisitArrivalTime(Visit visit);
        bool Save();
        bool VisitExists(int id);
    }
}



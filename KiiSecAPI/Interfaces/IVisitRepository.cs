using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitRepository
    {
        ICollection<Visit> GetVisits();
    }
}



using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitRequestRepository
    {
        ICollection<VisitRequest> GetVisitRequests();
    }
}



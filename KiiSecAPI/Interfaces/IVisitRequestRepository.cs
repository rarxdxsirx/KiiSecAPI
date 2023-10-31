using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitRequestRepository
    {
        ICollection<VisitRequest> GetVisitRequests();

        ICollection<VisitRequest> GetVisitRequestsByGroup(int groupID);
        bool VisitRequestExists(int id);

    }
}



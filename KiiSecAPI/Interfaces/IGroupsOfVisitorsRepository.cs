using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IGroupsOfVisitorsRepository
    {
        ICollection<GroupsOfVisitors> GetGroupsOfVisitors();
    }
}



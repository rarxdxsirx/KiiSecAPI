using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitorRepository
    {
        ICollection<Visitor> GetVisitors();
        Visitor GetVisitorByID(int id);
        bool CreateVisitor(int groupId, Visitor visitor);
        bool UpdateVisitor(int groupId, Visitor visitor);
        bool Save();
    }
}



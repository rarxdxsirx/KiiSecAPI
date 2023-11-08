using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitorRepository
    {
        ICollection<Visitor> GetVisitors();
        Visitor GetVisitorByID(int id);
        bool VisitorExists(int id);
        bool CreateVisitor(Visitor visitor);
        bool UpdateVisitor(Visitor visitor);
        bool Save();
    }
}



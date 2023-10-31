using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IVisitorRepository
    {
        ICollection<Visitor> GetVisitors();
    }
}



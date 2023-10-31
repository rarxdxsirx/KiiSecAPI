using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IOrganizationRepository
    {
        ICollection<Organization> GetOrganization();
        Organization GetOrganization(int id);
        
    }
}



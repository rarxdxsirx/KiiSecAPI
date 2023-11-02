using KiiSecAPI.Models;

namespace KiiSecAPI.Intefaces
{
    public interface IOrganizationRepository
    {
        ICollection<Organization> GetOrganization();
        Organization GetOrganization(int id);
        public bool OrganizationExists(int id);
        public bool CreateOrganization(Organization organization);
        public bool Save();

        //TODO Update and Delete Organization
    }
}



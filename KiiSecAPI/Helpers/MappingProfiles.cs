using AutoMapper;
using KiiSecAPI.Dto;
using KiiSecAPI.Models;

namespace KiiSecAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();
            CreateMap<Organization, OrganizationDto>();
            CreateMap<OrganizationDto, Organization>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeePermissions, EmployeePermissionsDto>();
            CreateMap<GroupsOfVisitors, GroupsOfVisitorsDto>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<Visitor, VisitorDto>();
            CreateMap<VisitorDto, Visitor>();
            CreateMap<VisitorsGroup,VisitorsGroupDto>();
        }
    }
}

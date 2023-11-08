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
            CreateMap<EmployeePermissionsDto, EmployeePermissions>();
            CreateMap<VisitOfVisitor, VisitOfVisitorDto>();
            CreateMap<VisitOfVisitorDto, VisitOfVisitor>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();
            CreateMap<Visitor, VisitorDto>();
            CreateMap<VisitorDto, Visitor>();
        }
    }
}

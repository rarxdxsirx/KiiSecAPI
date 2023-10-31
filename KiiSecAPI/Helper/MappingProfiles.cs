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
            CreateMap<Organization, OrganizationDto>();
        }
    }
}

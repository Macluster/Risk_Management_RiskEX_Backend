using AutoMapper;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<DepartmentDTO, Department>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Name));

            CreateMap<ProjectDTO, Project>()
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProjectName))
                       .ForMember(dest => dest.DepartmentId, opt => opt.Ignore());
        }
    }
}

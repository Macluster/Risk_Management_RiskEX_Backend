using AutoMapper;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}

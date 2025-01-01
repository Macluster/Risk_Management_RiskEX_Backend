using AutoMapper;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend
{
    public class MappingConfig : Profile
    {
        private const string DEFAULT_PASSWORD = "experion@123";

        public MappingConfig()
        {
            CreateMap<DepartmentDTO, Department>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Name));

            CreateMap<ProjectDTO, Project>()
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProjectName))
                       .ForMember(dest => dest.DepartmentId, opt => opt.Ignore());


            CreateMap<ApprovalDTO, Risk>()
                .ForMember(dest => dest.RiskId, opt => opt.MapFrom(src => src.RiskId))
                .ForMember(dest => dest.RiskName, opt => opt.MapFrom(src => src.RiskName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.PlannedActionDate, opt => opt.MapFrom(src => src.PlannedActionDate))
                .ForMember(dest => dest.RiskType, opt => opt.MapFrom(src => (int)src.RiskType))
                .ForMember(dest => dest.OverallRiskRating, opt => opt.MapFrom(src => src.OverallRiskRating))
                .ForMember(dest => dest.RiskStatus, opt => opt.MapFrom(src => src.RiskStatus));


            CreateMap<RiskDTO, Risk>();
            CreateMap<RiskAssessmentDTO, RiskAssessment>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<UsersDTO, User>()
                    // Map basic fields
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))

                     // Set default password
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => DEFAULT_PASSWORD))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))

                     // Handle nullable properties (Department & Projects)
                     .ForMember(dest => dest.DepartmentId, opt => opt.Ignore()) // Set in repository based on validation
                     .ForMember(dest => dest.Projects, opt => opt.Ignore())     // Set dynamically in the repository

                     // Audit fields
                     .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                      .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                     .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Optional: handled in repository
                     .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Optional: handled in repository

                      // Ignore navigation properties not relevant for this mapping
                      .ForMember(dest => dest.Department, opt => opt.Ignore())
                      .ForMember(dest => dest.ResponsibleRisks, opt => opt.Ignore())
                      .ForMember(dest => dest.CreatedRisks, opt => opt.Ignore())
                      .ForMember(dest => dest.UpdatedRisks, opt => opt.Ignore())
                      .ForMember(dest => dest.CreatedProjects, opt => opt.Ignore())
                      .ForMember(dest => dest.UpdatedProjects, opt => opt.Ignore())
                      .ForMember(dest => dest.CreatedExternalReviewers, opt => opt.Ignore())
                      .ForMember(dest => dest.UpdatedExternalReviewers, opt => opt.Ignore())
                      .ForMember(dest => dest.CreatedReviews, opt => opt.Ignore())
                      .ForMember(dest => dest.UpdatedReviews, opt => opt.Ignore())
                      .ForMember(dest => dest.CreatedUsers, opt => opt.Ignore())
                       .ForMember(dest => dest.UpdatedUsers, opt => opt.Ignore())
                       .ForMember(dest => dest.Reviews, opt => opt.Ignore());


            CreateMap<RiskResponseDTO, Risk>().ReverseMap();


            CreateMap<User, UsersDTO>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
               .ForMember(dest => dest.ProjectNames, opt => opt.MapFrom(src => src.Projects.Select(p => p.Name).ToList()));

            // Mapping for LoginRequestDTO (no mapping needed as it's a simple DTO)
            CreateMap<LoginRequestDTO, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            // Mapping for LoginResponseDTO
            CreateMap<User, LoginResponseDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Token, opt => opt.Ignore()); // Token is generated separately

            //Mapping for ReportDTO
            CreateMap<Risk, ReportDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ResponsibleUser.Email));


            CreateMap<ReportDTO, Risk>().ReverseMap();

            //Mapping for ExternalReviewerDTO
            CreateMap<ExternalReviewer, ExternalReviewerDTO>()
               .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id));


            CreateMap<ExternalReviewerDTO, ExternalReviewer>().ReverseMap();
            CreateMap< AssigneeResponseDTO,User>().ReverseMap();
            CreateMap<ApprovalDTO, Risk>().ReverseMap();


        }


    }
}

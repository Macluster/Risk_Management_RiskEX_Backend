namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class UserWithProjectsDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<ProjectWithUsersDto> Projects { get; set; }
    }

    public class ProjectWithUsersDto
    {
        public string ProjectName { get; set; }
        public List<UserDto> RelatedUsers { get; set; }
    }

    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class GetAllRiskAssignedDTO
    {

        public int Id { get; set; }
        public string RiskId { get; set; }


        public string RiskName { get; set; }
        public string DepartmentName { get; set; }
        public string ResponsibleUser {  get; set; }


        public string Description { get; set; }
        public string RiskType { get; set; }
        public int OverallRiskRating { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public String? RiskStatus { get; set; }

    }
}

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskMinimalInfoDTO
    {

       public int Id { get; set; }
       public string RiskName { get; set; }
       public DateTime PlannedActionDate { get; set; }
       public int OverallRiskRating { get; set; }


    }
}

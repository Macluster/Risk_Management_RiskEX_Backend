using Risk_Management_RiskEX_Backend.Models;

public class RiskStatusUpdateDTO
{
  
    public DateTime? ClosedDate { get; set; }
    public RiskStatus RiskStatus { get; set; }
    public string? Remarks { get; set; }

}
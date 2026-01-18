namespace Risk_Management_RiskEX_Backend.Models.DTO
{
  public class OpenRiskCountByTypeDTO
  { 
   
    public string RiskType { get; set; }
    public int OpenCount  { get; set; }
    public int ClosedCount { get; set; }
  }
}

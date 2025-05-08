using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskMongoService
    {


        Task CreateAsync(RiskDraftDTO newBook);
        Task<List<Object>> GetAllDraftsAsync();
        Task<bool> DeleteDraftByIdAsync(string riskId);
        Task<List<Object>> GetAllDraftsByDepartmentIdAsync(int departmentId);
        Task<List<RiskDraftDTO>> GetAllDraftsByCreatedUserAsync(int createdBy);
        Task<RiskDraftDTO> GetDraftByIdAsync(string riskId);
        Task UpdateAsync(string id, RiskDraftDTO updatedDraft);


    }
}

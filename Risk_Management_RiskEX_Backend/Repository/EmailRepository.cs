using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class EmailRepository : IEmailRepository
    {
        //public Task<bool> SendAssignmentEmailAsync(int riskId)
        //{
        //    throw new NotImplementedException();
        //}
        private readonly IEmailService _emailService;

        private readonly ApplicationDBContext _db;
        private readonly IUserRepository _userRepository;

        public EmailRepository(IEmailService emailService, ApplicationDBContext db, IUserRepository userRepository)
        {
            _emailService = emailService;
            _db = db;
            _userRepository = userRepository;
            
        }

        // Assuming you are using Entity Framework Core (EF Core)
        public async Task<(string FullName, string Email)> GetResponsibleUserDetailsAsync(int riskId)
        {
            var risk = await _db.Risks
                                .Where(r => r.Id == riskId)
                                .Include(r => r.ResponsibleUser)  // Eager loading the ResponsibleUser
                                .FirstOrDefaultAsync();

            if (risk == null || risk.ResponsibleUser == null)
            {
                // Handle case where risk or responsible user is not found
                throw new KeyNotFoundException($"Risk with ID {riskId} or associated responsible user not found.");
            }

            return (risk.ResponsibleUser.FullName, risk.ResponsibleUser.Email);
        }


        public async Task<bool> SendAssignmentEmailAsync(int riskId)
        {
            // Fetch risk details
            var risk = await _db.Risks
                .FindAsync(riskId);

            if (risk == null)
            {
                throw new KeyNotFoundException($"Risk with ID {riskId} not found.");
            }

            // Fetch assignee details
            //var assignee = await _userRepository.GetInfoOfAssigneeByRiskId(riskId);

            //if (assignee == null)
            //{
            //    throw new KeyNotFoundException($"Assignee for Risk ID {riskId} not found.{assignee}");
            //}

            //// Validate required fields
            //if (string.IsNullOrWhiteSpace(assignee.Email))
            //{
            //    throw new InvalidOperationException($"Assignee email is missing for Risk ID {riskId}.");
            //}
            var responsibleUserDetails = await GetResponsibleUserDetailsAsync(riskId);

            // Compose email content
            var subject = "Risk Assignment Notification";
            var body = $@"
                Dear {responsibleUserDetails.FullName},

                You have been assigned the following risk:

                Risk Name: {risk.RiskName}
                Description: {risk.Description}
                Risk Type: {risk.RiskType}
                Planned Action Date: {risk.PlannedActionDate:yyyy-MM-dd}

                Please log in to the system to view and manage this risk.

                Best regards,
                Risk Management Team,
                Experion Technologies Pvt. Ltd.
            ";

            // Send email
            await _emailService.SendEmail(responsibleUserDetails.Email,subject,body);

            return true;
        }
    }
}

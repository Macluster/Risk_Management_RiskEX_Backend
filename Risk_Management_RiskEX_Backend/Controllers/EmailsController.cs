using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Services;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailsController:ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly IEmailRepository _emailRepository;
        private readonly IRiskRepository _riskRepository;
        private readonly IUserRepository _userRepository;

        public EmailsController(IEmailService emailService,IRiskRepository riskRepository , IUserRepository userRepository, IEmailRepository emailRepository)
        {
            this.emailService = emailService;
            _riskRepository = riskRepository;
            _userRepository = userRepository;
            _emailRepository = emailRepository;


        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(string receptor, string subject, string body)
        {
            await emailService.SendEmail(receptor, subject, body);
            return Ok();
        }
        //[HttpPost("send-assignment-email")]
        //public async Task<IActionResult> SendAssignmentEmail(int riskId)
        //{
        //    Risk risk = await _riskRepository.GetRiskById(riskId) as Risk;
        //    if (risk == null)
        //    {
        //        return NotFound($"Risk with ID {riskId} not found.");
        //    }

        //    AssigneeResponseDTO assignee = await _userRepository.GetInfoOfAssigneeByRiskId(riskId) as AssigneeResponseDTO;

        //    if (assignee == null)
        //    {
        //        return NotFound($"Assignee for Risk ID {riskId} not found.");
        //    }
        //    Console.WriteLine("assignee", assignee);

        //    var subject = $"New Risk Assigned: {risk.RiskName}";
        //    var body = $@"
        //        Hello {assignee.FullName},

        //        A new risk has been assigned to you. Please find the details below:

        //        Risk ID: {risk.Id}
        //        Risk Name: {risk.RiskName}
        //        Description: {risk.Description}
        //        Risk Type: {risk.RiskType}
        //        Planned Action Date: {risk.PlannedActionDate:yyyy-MM-dd}
        //        Overall Risk Rating: {risk.OverallRiskRating}

        //        Please review and take the necessary action.

        //        Regards,
        //        Risk Management Team
        //    ";




        //    //await emailService.SendEmail();
        //    await emailService.SendEmail(assignee.Email, subject, body);
        //    return Ok();
        //}


        [HttpPost("send-assignment-email/{riskId}")]
        public async Task<IActionResult> SendAssignmentEmail(int riskId)
        {
            try
            {
                //await _emailRepository.SendAssignmentEmailAsync(riskId);
                //return Ok(new { message = "Email sent successfully." });
                bool emailSent = await _emailRepository.SendAssignmentEmailAsync(riskId);
                if (emailSent)
                {
                    return Ok("Email sent successfully.");
                }
                return BadRequest("Failed to send email.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred while sending the email." });
            }
        }

    }
}

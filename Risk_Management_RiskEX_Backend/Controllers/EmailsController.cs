//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Risk_Management_RiskEX_Backend.Data;
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
        private readonly ApplicationDBContext _db;
        private readonly IConfiguration _configuration;
        private readonly string _secretKey;
        private readonly IApprovalRepository _approvalRepository;



        public EmailsController(IEmailService emailService)
        {
            this.emailService = emailService;
           
            _secretKey = Environment.GetEnvironmentVariable("API_SECRET");


        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(string receptor, string subject, string body)
        {
            await emailService.SendEmail(receptor, subject, body);
            return Ok();
        }


        //[HttpPost("send-assignment-email/{riskId}")]
        //public async Task<IActionResult> SendAssignmentEmail(int riskId)
        //{
        //    try
        //    {
        //        //await _emailRepository.SendAssignmentEmailAsync(riskId);
        //        //return Ok(new { message = "Email sent successfully." });
        //        bool emailSent = await _emailRepository.SendAssignmentEmailAsync(riskId);
        //        if (emailSent)
        //        {
        //            return Ok("Email sent successfully.");
        //        }
        //        return BadRequest("Failed to send email.");
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(new { error = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { error = "An unexpected error occurred while sending the email." });
        //    }
        //}

    }
}

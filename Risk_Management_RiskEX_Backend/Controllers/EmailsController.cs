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



        public EmailsController(IEmailService emailService,IRiskRepository riskRepository , IUserRepository userRepository, IEmailRepository emailRepository,ApplicationDBContext db,IConfiguration configuration, IApprovalRepository approvalRepository)
        {
            this.emailService = emailService;
            _riskRepository = riskRepository;
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _db = db;
            _configuration = configuration;
            _approvalRepository = approvalRepository;
            _secretKey = Environment.GetEnvironmentVariable("API_SECRET");


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

        //public class EmailToken
        //{
        //    public int ReviewId { get; set; }
        //    public int RiskId { get; set; }
        //    public string Action { get; set; }
        //    public DateTime ExpiryTime { get; set; }
        //}

        //[HttpPost("send-review-email")]
        //public async Task<IActionResult> SendReviewEmail(int riskId, int reviewId, string reviewerEmail)
        //{
        //    // Create a secure token containing review information
        //    var token = new EmailToken
        //    {
        //        ReviewId = reviewId,
        //        RiskId = riskId,
        //        ExpiryTime = DateTime.UtcNow.AddDays(7)
        //    };

        //    string tokenString = GenerateSecureToken(token);

        //    string baseUrl = _configuration["ApplicationUrl"] ?? "https://localhost:7216";
        //    string approveUrl = $"{baseUrl}/api/review/process-review?token={tokenString}&action=approved";
        //    string rejectUrl = $"{baseUrl}/api/review/process-review?token={tokenString}&action=rejected";

        //    string emailBody = @$"
        //<html>
        //    <body>
        //        <h2>Risk Review Request</h2>
        //        <p>You have been requested to review a risk assessment.</p>
        //        <p>Risk ID: {riskId}</p>
        //        <div style='margin: 20px 0;'>
        //            <a href='{approveUrl}' style='background-color: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; margin-right: 10px;'>Approve</a>
        //            <a href='{rejectUrl}' style='background-color: #f44336; color: white; padding: 10px 20px; text-decoration: none;'>Reject</a>
        //        </div>
        //    </body>
        //</html>";

        //    await emailService.SendEmail(reviewerEmail, "Risk Review Request", emailBody);
        //    return Ok();
        //}

        //[HttpGet("process-review")]
        //public async Task<IActionResult> ProcessReview([FromQuery] string token, [FromQuery] string action)
        //{
        //    var emailToken = ValidateToken(token);
        //    if (emailToken == null || emailToken.ExpiryTime < DateTime.UtcNow)
        //    {
        //        return BadRequest("Invalid or expired token");
        //    }

        //    var success = await _approvalRepository.UpdateReviewStatusAsync(emailToken.RiskId, action);
        //    if (!success)
        //    {
        //        return BadRequest("Failed to update review status");
        //    }

        //    // Redirect to a success page
        //    return Redirect($"/review-confirmation?status={action}");
        //}

        //private string GenerateSecureToken(EmailToken token)
        //{
        //    // Implement secure token generation using encryption
        //    // You can use JWT or any other secure token format
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_secretKey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //        new Claim("reviewId", token.ReviewId.ToString()),
        //        new Claim("riskId", token.RiskId.ToString()),
        //        new Claim("expiry", token.ExpiryTime.ToString())
        //    }),
        //        Expires = token.ExpiryTime,
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(securityToken);
        //}
        //private EmailToken ValidateToken(string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_secretKey);

        //        var tokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            ClockSkew = TimeSpan.Zero
        //        };

        //        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

        //        var emailToken = new EmailToken
        //        {
        //            ReviewId = int.Parse(principal.FindFirst("reviewId").Value),
        //            RiskId = int.Parse(principal.FindFirst("riskId").Value),
        //            ExpiryTime = DateTime.Parse(principal.FindFirst("expiry").Value)
        //        };

        //        return emailToken;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}


    }
}

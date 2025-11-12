using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Services;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/emails")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EmailsController:ControllerBase
    {
        private readonly IEmailService _emailService;
       
        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;

        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(
             [FromQuery] string receptor,
             [FromQuery] string subject,
             [FromQuery] string body,
             [FromQuery] bool isBodyHtml = false)
        {
            try
            {
                if (string.IsNullOrEmpty(receptor) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
                {
                    return BadRequest(new { error = "Missing required parameters" });
                }

                await _emailService.SendEmail(receptor, subject, body);
                return Ok(new { message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email error: {ex.Message}");
                return StatusCode(400, new { error = "Failed to send email", details = ex.Message });
            }
        }


    }
}

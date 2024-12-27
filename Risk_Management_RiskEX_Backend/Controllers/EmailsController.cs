using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailsController:ControllerBase
    {
        private readonly IEmailService emailService;
        public EmailsController(IEmailService emailService)
        {
            this.emailService = emailService;
            
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(string receptor, string subject, string body)
        {
            await emailService.SendEmail(receptor, subject, body);
            return Ok();
        }
    }
}

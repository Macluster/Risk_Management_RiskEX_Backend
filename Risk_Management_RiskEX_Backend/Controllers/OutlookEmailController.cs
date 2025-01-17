//using Microsoft.AspNetCore.Mvc;
//using Risk_Management_RiskEX_Backend.Interfaces;
//using Risk_Management_RiskEX_Backend.Models.DTO;
//using Risk_Management_RiskEX_Backend.Services;

//namespace Risk_Management_RiskEX_Backend.Controllers
//{
//    [Route("api/emails")]
//    [ApiController]
//    public class OutlookEmailController: ControllerBase
//    {
//        private readonly IEmailService emailService;

//        public OutlookEmailController(IEmailService emailService)
//        {
//            this.emailService = emailService;
//        }
//        [HttpPost]
//        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)

//        {
//            if (string.IsNullOrWhiteSpace(request.Receptor) || !request.Receptor.Contains("@"))
//                return BadRequest("Invalid email address.");

//            try
//            {
//                await emailService.SendEmail(request.Receptor, request.Subject, request.Body);
//                return Ok(new { message = "Email sent successfully!" });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new { error = ex.Message });
//            }
//        }

//    }
//}

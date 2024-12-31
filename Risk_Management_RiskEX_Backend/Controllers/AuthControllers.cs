using System.Net;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthControllers : ControllerBase
    {
        private IAuthRepository _authRepository;

        public AuthControllers(IAuthRepository authRepository)
        {
            _authRepository = authRepository;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromServices] IAuthRepository _authRepository, [FromBody] LoginRequestDTO model)
        {
            try
            {
                var loginResponse = await _authRepository.LoginUser(model);
                if (loginResponse == null)
                {
                    return BadRequest(new { message = "Invalid email or password" });
                }
                return Ok(loginResponse);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }

    }
}

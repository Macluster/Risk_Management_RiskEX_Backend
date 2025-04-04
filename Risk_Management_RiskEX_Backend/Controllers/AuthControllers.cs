﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Services;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthControllers : ControllerBase
    {
        private IAuthRepository _authRepository;
        private readonly UserService _userService;

        public AuthControllers(IAuthRepository authRepository, UserService userService)
        {
            _authRepository = authRepository;
            _userService = userService;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromServices] IAuthRepository _authRepository, [FromBody] LoginRequestDTO model)
        {
          
            try
            {
              

                var loginResponse = await _userService.Login(model);
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


        [HttpPost("ssologin")]
        public async Task<IActionResult> Login(MicrosoftLoginRequestDTO request)
        {
           

            try
            {
                var response = await _authRepository.LoginUserWithMicrosoft(request.Email);
                if (response == null)
                {
                    return BadRequest(new { message = "You do not have access to the system. Please contact the administrator.." });
                }
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new  { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new  { message = "An error occurred while processing your request" });
            }
        }


        [HttpPost("GetHashedPassword")]
        public async Task<IActionResult> GetHashedpassword([FromServices] IAuthRepository _authRepository, [FromBody] LoginRequestDTO model)
        {

            try
            {


                var loginResponse =  _userService.GetHashedPassword(model.Password);
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

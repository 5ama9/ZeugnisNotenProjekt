using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Interfaces;
using Shared.Models.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public ActionResult<LoginResponseDto> Login(LoginRequestDto loginRequest)
        {
            LoginResponseDto? result = _authService.Login(loginRequest);

            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}

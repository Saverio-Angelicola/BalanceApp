using BalanceApp.API.Dtos.Users;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.UI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;

        public AuthController(IUserService userService, IAuthService authService, ITokenService tokenService)
        {
            this.userService = userService;
            this.authService = authService;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto registerDto)
        {
            try
            {
                return Ok(await userService.CreateUser(registerDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto user)
        {
            try
            {
                return Ok(await authService.Login(user));
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        [HttpGet("profile"), Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetUsernameFromJwtToken(bearerToken);
                return Ok(await userService.GetUserByUsername(username));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.UI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRegistrationService userRegistrationService;
        private readonly IUserFetcherService userFetcherService;
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;

        public AuthController(IUserRegistrationService userRegistrationService, IAuthService authService, ITokenService tokenService, IUserFetcherService userFetcherService)
        {
            this.userRegistrationService = userRegistrationService;
            this.authService = authService;
            this.tokenService = tokenService;
            this.userFetcherService = userFetcherService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto registerDto)
        {
            try
            {
                return Ok(await userRegistrationService.RegisterUser(registerDto));
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
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userFetcherService.GetUserByEmail(email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

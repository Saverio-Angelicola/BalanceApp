using BalanceApp.Application.Dtos.Auth;
using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRegistrationService userRegistrationService;
        private readonly IUserFetcherService userFetcherService;
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;
        private readonly ILogger<AuthController> logger;

        public AuthController(IUserRegistrationService userRegistrationService,
                IAuthService authService,
                ITokenService tokenService,
                IUserFetcherService userFetcherService,
                ILogger<AuthController> logger

            )
        {
            this.userRegistrationService = userRegistrationService;
            this.authService = authService;
            this.tokenService = tokenService;
            this.userFetcherService = userFetcherService;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto registerDto)
        {
            try
            {
                return Ok(new UserDto(await userRegistrationService.RegisterUser(registerDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("withings/register")]
        public async Task<IActionResult> RegisterWithingsAccount()
        {
            try
            {
                var code = HttpContext.Request.Query["code"].ToString();
                var email = HttpContext.Request.Query["state"].ToString();
                await userRegistrationService.RegisterRefreshToken(email, code);
                return Redirect("https://balanceappclient.pages.dev/login");

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
                logger.LogError($"Error - {DateTime.Now} : {ex.Message}");
                logger.LogError($"email : {user.Email} - password : {user.Password}");
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
                return Ok(new UserDto(await userFetcherService.GetUserByEmail(email)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

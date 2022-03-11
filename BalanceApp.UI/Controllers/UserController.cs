using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.UI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpDelete("delete"), Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userService.DeleteUser(username));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("user/infos/update"), Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUser)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userService.UpdateUser(username, updateUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("user/password/update"), Authorize]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordDto updatePassword)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userService.UpdatePassword(username, updatePassword));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

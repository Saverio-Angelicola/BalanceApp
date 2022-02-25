using BalanceApp.API.Dtos.Users;
using BalanceApp.API.Services.interfaces.Auth;
using BalanceApp.API.Services.interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
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

        [HttpDelete("profile/delete"), Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                string username = tokenService.GetUsernameFromJwtToken(HttpContext);
                return Ok(await userService.DeleteUser(username));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("profile/infos/update"), Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUser)
        {
            try
            {
                string username = tokenService.GetUsernameFromJwtToken(HttpContext);
                return Ok(await userService.UpdateUser(username, updateUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("profile/password/update"), Authorize]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordDto updatePassword)
        {
            try
            {
                string username = tokenService.GetUsernameFromJwtToken(HttpContext);
                return Ok(await userService.UpdatePassword(username, updatePassword));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

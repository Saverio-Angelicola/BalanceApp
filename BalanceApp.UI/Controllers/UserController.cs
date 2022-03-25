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
        private readonly IUserUpdaterService userUpdaterService;
        private readonly ITokenService tokenService;
        private readonly IUserDeletionService userDeletionService;

        public UserController(IUserUpdaterService userUpdaterService, ITokenService tokenService, IUserDeletionService userDeletionService)
        {
            this.userUpdaterService = userUpdaterService;
            this.tokenService = tokenService;
            this.userDeletionService = userDeletionService;
        }

        [HttpDelete("delete"), Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userDeletionService.DeleteUser(username));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("infos/update"), Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUser)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userUpdaterService.UpdateUser(username, updateUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("password/update"), Authorize]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordDto updatePassword)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await userUpdaterService.UpdatePassword(username, updatePassword));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

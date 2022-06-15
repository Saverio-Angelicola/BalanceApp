using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Users;
using BalanceApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUpdaterService userUpdaterService;
        private readonly ITokenService tokenService;
        private readonly IUserDeletionService userDeletionService;
        private readonly IUserFetcherService userFetcherService;

        public UserController(IUserFetcherService userFetcherService, IUserUpdaterService userUpdaterService, ITokenService tokenService, IUserDeletionService userDeletionService)
        {
            this.userUpdaterService = userUpdaterService;
            this.tokenService = tokenService;
            this.userDeletionService = userDeletionService;
            this.userFetcherService = userFetcherService;
        }

        [HttpGet, Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await userFetcherService.GetAllUser();
                List<UserDto> userDtos = new();
                users.ForEach(u => userDtos.Add(new UserDto(u)));
                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete"), Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string username = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(new UserDto(await userDeletionService.DeleteUser(username)));
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
                return Ok(new UserDto(await userUpdaterService.UpdateUser(username, updateUser)));
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
                return Ok(new UserDto(await userUpdaterService.UpdatePassword(username, updatePassword)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

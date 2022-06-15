using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Services.interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserUpdaterService userUpdaterService;
        private readonly IUserFetcherService userFetcherService;
        private readonly IUserRegistrationService userRegistrationService;
        private readonly ILogger<AdminController> logger;

        public AdminController(IUserUpdaterService userUpdaterService, 
            IUserFetcherService userFetcherService, 
            IUserRegistrationService userRegistrationService, 
            ILogger<AdminController> logger)
        {
            this.userUpdaterService = userUpdaterService;
            this.userFetcherService = userFetcherService;
            this.userRegistrationService = userRegistrationService;
            this.logger = logger;
        }

        [HttpPost("user/edit"), Authorize(Roles ="Admin")]
        public async Task<IActionResult> EditUser(UpdateUserDto updatedUser)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = updatedUser.Email;
                return Ok(new UserDto(await userUpdaterService.UpdateUser(email, updatedUser)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById([FromRoute(Name = "id")] Guid id)
        {
            try
            {
                return Ok(new UserDto(await userFetcherService.GetUserById(id)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("user/add")]
        public async Task<IActionResult> AddUser(CreateDoctorDto registerDto)
        {
            try
            {
                return Ok(new UserDto(await userRegistrationService.RegisterDoctor(registerDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

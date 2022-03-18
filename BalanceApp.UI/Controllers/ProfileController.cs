using BalanceApp.Application.Dtos.Profiles;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.UI.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileCreatorService profileCreatorService;
        private readonly IProfileUpdaterService profileUpdaterService;
        private readonly IProfileDeletionService profileDeletionService;
        private readonly IProfileFetcherService profileFetcherService;
        private readonly ITokenService tokenService;

        public ProfileController(
            IProfileCreatorService profileCreatorService, IProfileUpdaterService profileUpdaterService,
            IProfileDeletionService profileDeletionService, IProfileFetcherService profileFetcherService,
            ITokenService tokenService)
        {
            this.profileCreatorService = profileCreatorService;
            this.profileUpdaterService = profileUpdaterService;
            this.profileDeletionService = profileDeletionService;
            this.profileFetcherService = profileFetcherService;
            this.tokenService = tokenService;
        }

        [HttpPost("profile"), Authorize]
        public IActionResult CreateProfile(CreateProfileDto profileDto)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                profileCreatorService.CreateProfile(email, profileDto);
                return Created("profile", profileDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("profile/{id}"), Authorize]
        public async Task<IActionResult> GetProfile([FromRoute(Name = "id")] Guid id)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await profileFetcherService.GetProfile(email, id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPatch("profile/{id}"), Authorize]
        public IActionResult UpdateProfile([FromRoute(Name = "id")] Guid id, UpdateProfileDto profileDto)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                profileUpdaterService.UpdateProfile(email, id, profileDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("profile/{id}"), Authorize]
        public IActionResult DeleteProfile([FromRoute(Name = "id")] Guid id)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                profileDeletionService.DeleteProfile(email, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

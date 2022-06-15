using BalanceApp.Application.Dtos.Users;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IBodyDataFetcherService bodyDataFetcherService;
        private readonly ILogger<AdminController> logger;

        public DoctorController(IBodyDataFetcherService bodyDataFetcherService, ILogger<AdminController> logger)
        {
            this.bodyDataFetcherService = bodyDataFetcherService;
            this.logger = logger;
        }

        [HttpGet("user/{id}"), Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetUserById([FromRoute(Name = "id")] Guid id)
        {
            try
            {
                return Ok(await bodyDataFetcherService.GetBodyDataById(id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}

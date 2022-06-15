using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
{
    [Route("api/bodydata")]
    [ApiController]
    public class BodyDataController : ControllerBase
    {
        private readonly IBodyDataFetcherService bodyDataFetcherService;
        private readonly ITokenService tokenService;

        public BodyDataController(IBodyDataFetcherService bodyDataFetcherService, ITokenService tokenService)
        {
            this.bodyDataFetcherService = bodyDataFetcherService;
            this.tokenService = tokenService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllBodyData()
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                string token = tokenService.GetWithingsTokenFromJwtToken(bearerToken);
                var list = await bodyDataFetcherService.GetAllBodyData(email,token);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
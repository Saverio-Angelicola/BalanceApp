using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Services.interfaces.Auth;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.UI.Controllers
{
    [Route("api/bodydata")]
    [ApiController]
    public class BodyDataController : ControllerBase
    {
        private readonly IBodyDataFetcherService bodyDataFetcherService;
        private readonly IBodyDataCreatorService bodyDataCreatorService;
        private readonly ITokenService tokenService;

        public BodyDataController(IBodyDataFetcherService bodyDataFetcherService, ITokenService tokenService, IBodyDataCreatorService bodyDataCreatorService)
        {
            this.bodyDataFetcherService = bodyDataFetcherService;
            this.tokenService = tokenService;
            this.bodyDataCreatorService = bodyDataCreatorService;
        }

        [HttpGet,Authorize]
        public async Task<IActionResult> GetAllBodyData()
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                return Ok(await bodyDataFetcherService.GetAllBodyData(email));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddBodyData(BodyDataDto bodyData)
        {
            try
            {
                string bearerToken = HttpContext.Request.Headers.Authorization;
                string email = tokenService.GetEmailFromJwtToken(bearerToken);
                await bodyDataCreatorService.AddBodyData(email, bodyData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
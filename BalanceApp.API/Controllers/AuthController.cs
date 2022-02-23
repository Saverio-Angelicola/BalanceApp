﻿using BalanceApp.API.Dtos.Auth;
using BalanceApp.API.Dtos.Users;
using BalanceApp.API.Entities;
using BalanceApp.API.Services.interfaces.Auth;
using BalanceApp.API.Services.interfaces.Tokens;
using BalanceApp.API.Services.interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApp.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;

        public AuthController(IUserService userService, IAuthService authService, ITokenService tokenService)
        {
            this.userService = userService;
            this.authService = authService;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(CreateUserDto registerDto)
        {
            try
            {
                return Ok(await userService.CreateUser(registerDto));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto user)
        {
            try
            {
                return Ok(await authService.Login(user));
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }

        [HttpGet("profile"), Authorize]
        public async Task<ActionResult<User>> GetProfile()
        {
            try
            {
                string username = tokenService.GetUsernameFromJwtToken(HttpContext);
                return Ok(await userService.GetUserByUsername(username));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

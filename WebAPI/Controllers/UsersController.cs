using Application.Features.Auths.Commands;
using Application.Features.Auths.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(registeredDto.RefreshToken);
            return Created("", registeredDto.AccessToken);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            LoggedInDto loggedInDto = await Mediator.Send(loginCommand);
            SetRefreshTokenToCookie(loggedInDto.RefreshToken);
            return Ok(loggedInDto.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}

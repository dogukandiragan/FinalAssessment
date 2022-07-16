using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalAssessment.Core.Services;
using FinalAssessment.Core.DTOs;

namespace FinalAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authenticationService)
        {
            _authService = authenticationService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authService.CreateTokenAsync(loginDto);
            return Ok(result);
        }

   

        [HttpPost("~/RevokeRefreshToken")]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authService.RevokeRefreshTokenAsync(refreshTokenDto.Token);
            return Ok(result);
        }



        [HttpPost("~/CreateTokenByRefreshToken")]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)

        {
            var result = await _authService.CreateTokenByRefreshTokenAsync(refreshTokenDto.Token);
            return Ok(result);
        }


    }
}
using FinalAssessment.Core.DTOs;

namespace FinalAssessment.Core.Services
{
    public interface IAuthService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
        Task<Response<EmptyDto>> RevokeRefreshTokenAsync(string refreshToken);
     
    }
}

using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;


namespace FinalAssessment.Core.Services
{


    public interface ITokenService
    {
        Task<TokenDto> CreateToken(UserApp userApp);
 
    }
}

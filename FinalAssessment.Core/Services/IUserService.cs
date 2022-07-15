using FinalAssessment.Core.DTOs;


namespace FinalAssessment.Core.Services
{
    public interface IUserService
    {

        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);


        Response<IEnumerable<UserAppDto>> GetAllUser();


    }
}

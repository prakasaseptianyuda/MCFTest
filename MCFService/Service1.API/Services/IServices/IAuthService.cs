using Service1.API.Models.Dtos;

namespace Service1.API.Services.IServices
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}

using MCF.Web.Models;

namespace MCF.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> Login(LoginRequestDto loginRequestDto);
    }
}
